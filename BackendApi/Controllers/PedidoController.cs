using BackendApi.Database.Context;
using BackendApi.Database.Entities;
using BackendApi.Extensions;
using BackendApi.Interfaces;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BackendApi.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<PedidoController> _logger;
        private readonly ISendEmailService _sendMail;

        public PedidoController(ApplicationContext context, ILogger<PedidoController> logger, ISendEmailService sendMail)
        {
            _context = context;
            _logger = logger;
            _sendMail = sendMail;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderBySellerAsync(string user, int page=1, int pageSize=2)
        {
            try
            {

                DataModel data = new DataModel
                {
                    Codemp = Convert.ToInt32(User.FindFirst("codemp")!.Value),
                    Codrep = Convert.ToInt32(User.FindFirst("codusu")!.Value),
                };

                 var representante = await _context.E090rep
                .Where(x => x.Codrep == data.Codrep)
                .Select(x => new RepresentanteModel
                {
                    CodRep = x.Codrep,
                    NomRep = x.Nomrep,
                    CodEmp = data.Codemp
                })
                .FirstOrDefaultAsync();

                if(representante != null)
                {
                    var query = _context.Usu_t009ppd
                                .AsNoTracking()
                                .Join(_context.Usu_t009ppi, pedido => pedido.UsuNumppd, produto => produto.UsuNumppd, (pedido, produto) => new { pedido, produto })
                                .Join(_context.E085cli, pp => pp.pedido.UsuCodcli, cliente => cliente.Codcli, (pp, cliente) => new { pp.pedido, pp.produto, cliente })
                                .Where(p => p.pedido.UsuCodrep == representante.CodRep && p.pedido.UsuCodemp == representante.CodEmp)
                                .GroupBy(p => p.produto.UsuNumppd)
                                .OrderByDescending(g => g.First().pedido.UsuDatemi)
                                .Select(g => new PedidoModel
                                {
                                    NumPpd = g.Key,
                                    NomCli = g.First().cliente.Nomcli,
                                    NumNfv = g.First().pedido.UsuNumnfv,
                                    DatEmi = g.First().pedido.UsuDatemi,
                                    Produtos = g.Select(p => new ProdutoModel
                                    {
                                        NumPpd = p.produto.UsuNumppd,
                                        SeqIpd = p.produto.UsuSeqipd,
                                        CodPro = p.produto.UsuCodpro,
                                        DescPro = p.produto.UsuDesnfv,
                                        PreUni = p.produto.UsuPreuni,
                                        Unimed = p.produto.UsuUnimed,
                                        Quantidade = p.produto.UsuQtdped,
                                        TotalPreco = p.produto.UsuPreuni * p.produto.UsuQtdped
                                    }).ToList()
                                });

                    var totalItems = await query.CountAsync();
                    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                    var produtos = await query
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

                    ViewData["Empresa"] = data.Codemp;

                    var viewModel = new PainelViewModel
                    {
                        Representante = representante,
                        Produtos = produtos,
                        PaginaAtual = page,
                        PageSize = totalPages,
                        Empresa = data.Codemp
                    };

                    return View("Painel", viewModel);
                }
                _logger.LogInformation($"Representante não encontrado no sistema");
                return NotFound("Representante não encontrado");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetLastOrders(BuscaPedidoViewModel request)
        {
            if(request.Cliente != null)
            {

                if (request.Cliente.IsCpf() || request.Cliente.IsCnpj())
                {
                    var data = Regex.Replace(request.Cliente, @"[^a-zA-Z0-9]", "");

                    var query = await _context.Usu_t009ppd
                                     .AsNoTracking()
                                     .Join(_context.Usu_t009ppi,
                                         pedido => pedido.UsuNumppd,
                                         produto => produto.UsuNumppd,
                                         (pedido, produto) => new { pedido, produto })
                                     .Join(_context.E085cli,
                                         pp => pp.pedido.UsuCodcli,
                                         cliente => cliente.Codcli,
                                         (pp, cliente) => new { pp.pedido, pp.produto, cliente })
                                     .Where(p => p.cliente.Cgccpf == Convert.ToInt64(data))
                                     .GroupBy(p => p.produto.UsuNumppd)
                                     .OrderByDescending(g => g.First().pedido.UsuDatemi)
                                     .Take(3)
                                     .Select(g => new PedidoModel
                                     {
                                         NumPpd = g.Key,
                                         NomCli = g.First().cliente.Nomcli,
                                         NumNfv = g.First().pedido.UsuNumnfv,
                                         DatEmi = g.First().pedido.UsuDatemi,
                                         Produtos = g.Select(p => new ProdutoModel
                                         {
                                             NumPpd = p.produto.UsuNumppd,
                                             SeqIpd = p.produto.UsuSeqipd,
                                             CodPro = p.produto.UsuCodpro,
                                             DescPro = p.produto.UsuDesnfv,
                                             PreUni = p.produto.UsuPreuni,
                                             Unimed = p.produto.UsuUnimed,
                                             Quantidade = p.produto.UsuQtdped,
                                             TotalPreco = p.produto.UsuPreuni * p.produto.UsuQtdped
                                         }).ToList()
                                     })
                                     .ToListAsync();

                    PedidoViewModel model = new PedidoViewModel()
                    {
                        Pedidos = query
                    };

                    return View("LastPedidos", model);
                }
                else
                {
                    var query = await _context.Usu_t009ppd
                                    .AsNoTracking()
                                    .Join(_context.Usu_t009ppi,
                                        pedido => pedido.UsuNumppd,
                                        produto => produto.UsuNumppd,
                                        (pedido, produto) => new { pedido, produto })
                                    .Join(_context.E085cli,
                                        pp => pp.pedido.UsuCodcli,
                                        cliente => cliente.Codcli,
                                        (pp, cliente) => new { pp.pedido, pp.produto, cliente })
                                    .Where(p => p.cliente.Nomcli == request.Cliente)
                                    .GroupBy(p => p.produto.UsuNumppd)
                                    .OrderByDescending(g => g.First().pedido.UsuDatemi)
                                    .Take(3)
                                    .Select(g => new PedidoModel
                                    {
                                        NumPpd = g.Key,
                                        NomCli = g.First().cliente.Nomcli,
                                        NumNfv = g.First().pedido.UsuNumnfv,
                                        DatEmi = g.First().pedido.UsuDatemi,
                                        Produtos = g.Select(p => new ProdutoModel
                                        {
                                            NumPpd = p.produto.UsuNumppd,
                                            SeqIpd = p.produto.UsuSeqipd,
                                            CodPro = p.produto.UsuCodpro,
                                            DescPro = p.produto.UsuDesnfv,
                                            PreUni = p.produto.UsuPreuni,
                                            Unimed = p.produto.UsuUnimed,
                                            Quantidade = p.produto.UsuQtdped,
                                            TotalPreco = p.produto.UsuPreuni * p.produto.UsuQtdped
                                        }).ToList()
                                    })
                                    .ToListAsync();

                    PedidoViewModel model = new PedidoViewModel()
                    {
                        Pedidos = query
                    };

                    return View("LastPedidos", model);
                }

            }
            _logger.LogInformation($"{request.Cliente} Invalido");
            return BadRequest("Dado Invalido para pesquisa");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> RenderPageCreateOrder(string numppd="")
        {
            DataModel data = new DataModel
            {
                Codemp = Convert.ToInt32(User.FindFirst("codemp")!.Value),
                Codrep = Convert.ToInt32(User.FindFirst("codusu")!.Value),
            };

            var result = await _context.E090rep.Select(x => new RepresentanteModel
            {
                CodRep = x.Codrep,
                NomRep = x.Nomrep,
            }).FirstOrDefaultAsync(x => x.CodRep == Convert.ToInt32(data.Codrep));


            if(numppd == "")
            {
                CreatePedidoViewModel model = new CreatePedidoViewModel()
                {
                    Representante = result!,
                };
                return View("CreatePedidoView", model);
            }
            else
            {

                var itens = await _context.Usu_t009ppi.Where(x => x.UsuNumppd == Convert.ToInt32(numppd))
                                                .Select(x => new ProdutoModel
                                                {
                                                    CodPro = x.UsuCodpro,
                                                    DescPro = x.UsuDesnfv,
                                                    Unimed = x.UsuUnimed,
                                                    Quantidade = x.UsuQtdped,
                                                    PreUni = x.UsuPreuni,
                                                    NumPpd = x.UsuNumppd
                                                }).ToListAsync();

                var codcli = await _context.Usu_t009ppd.Where(x => x.UsuNumppd == Convert.ToInt32(numppd))
                                                        .Select(x => x.UsuCodcli)
                                                        .FirstOrDefaultAsync();

                var cliente = await _context.E085cli.Where(x => x.Codcli == codcli)
                                                    .Select(x => new ClienteModel
                                                    {
                                                        CodCli = x.Codcli,
                                                        NomFantCli = x.Apecli,
                                                        UfCli = x.Sigufs,
                                                        Contato = x.Foncli,
                                                        Contato2 = x.Foncl2,
                                                        Cgccpf = x.Cgccpf,
                                                        NomCli = x.Nomcli,
                                                        Endereco = x.Endcli,
                                                        CepCli = x.Cepcli,
                                                        Cidade = x.Cidcli,
                                                        EmailCli = x.Emanfe,
                                                        FaxCli = x.Faxcli,
                                                        InscEstadual = x.Insest,
                                                        Bairro = x.Baicli

                                                    }).FirstOrDefaultAsync();


                CreatePedidoViewModel model = new CreatePedidoViewModel()
                {
                    Representante = result!,
                    Produtos = itens,
                    Cliente = cliente,
                    NumPpd = numppd,
                };

                return View("CreatePedidoView", model);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClientFormGenerateOrder(string cliente)
        {
            var query = await _context.E085cli.FirstOrDefaultAsync(x => x.Cgccpf == Convert.ToInt64(cliente));

            if(query != null)
            {
                ClienteModel dataClient = new ClienteModel()
                {
                    CodCli = query.Codcli,
                    NomFantCli = query.Apecli,
                    UfCli = query.Sigufs,
                    Contato = query.Foncli,
                    Contato2 = query.Foncl2,
                    Cgccpf = query.Cgccpf,
                    NomCli = query.Nomcli,
                    Endereco = query.Endcli,
                    CepCli = query.Cepcli,
                    Cidade = query.Cidcli,
                    EmailCli = query.Emanfe,
                    FaxCli = query.Faxcli,
                    InscEstadual = query.Insest,
                    Bairro = query.Baicli
                };
                
                return Ok(dataClient);
            }
            return NotFound("Cliente não encontrado");
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProductFromFormToGenerateOrder(string produto)
        {

            DataModel data = new DataModel
            {
                Codemp = Convert.ToInt32(User.FindFirst("codemp")!.Value),
                Codrep = Convert.ToInt32(User.FindFirst("codusu")!.Value),
            };

            if (data.Codemp == 99)
            {
                var query = await _context.E075pros.FirstOrDefaultAsync(x => x.Codpro == produto && x.UsuPreuni != null && x.Sitpro == "A" && x.Codori == "PSC");

                if (query != null)
                {
                    ProductModel product = new ProductModel()
                    {
                        Codpro = query.Codpro,
                        Desnfv = query.Desnfv,
                        Unimed = query.Unimed,
                        Codagc = query.Codagc,
                        Codfam = query.Codfam,
                        Finrec = query.UsuFinrec,

                    };

                    return Ok(product);
                }
            }
            else
            {
                var query = await _context.E075pros.FirstOrDefaultAsync(x => x.Codpro == produto && x.UsuPreuni != null && x.Sitpro == "A" && x.Codori == "PAP");

                if (query != null)
                {
                    ProductModel product = new ProductModel()
                    {
                        Codpro = query.Codpro,
                        Desnfv = query.Desnfv,
                        Unimed = query.Unimed,
                        Codagc = query.Codagc,
                        Codfam = query.Codfam,
                        Finrec = query.UsuFinrec,

                    };

                    return Ok(product);
                }
            }

            _logger.LogInformation($"Produto {produto} pesquisado não encontrado na base");
            return NotFound("Produto não encontrado");

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] DataPedidoViewModel pedido)
        {
            DataModel data = new DataModel
            {
                Codemp = Convert.ToInt32(User.FindFirst("codemp")!.Value),
                Codrep = Convert.ToInt32(User.FindFirst("codusu")!.Value),
            };

            try
            {
                var numPpd = await _context.Usu_t009ppd.MaxAsync(x => x.UsuNumppd);
                DateTime.TryParse(pedido.DatPrv, out DateTime datPrv);
                DateTime.TryParse(pedido.DatEmi, out DateTime datEmi);
                string retMer = pedido.RetMer == "1" ? "s" : "n";
                short sitPpd = (short)(pedido.SitPpd == "Não Enviado" ? 1 : 2);
                short codemp = (short)data.Codemp;


                T009PPD modelppd = new T009PPD()
                {
                    UsuNumppd = numPpd + 1,
                    UsuObsped = pedido.ObsPed,
                    UsuCodcli = pedido.CodCli,
                    UsuCodrep = pedido.CodRep,
                    UsuCodcpg = pedido.CodCpg,
                    UsuPedcli = pedido.PedCli,
                    UsuDatprv = datPrv,
                    UsuPedime = pedido.PedIme,
                    UsuTipfat = pedido.TipFat,
                    UsuNatope = pedido.NatOpe,
                    UsuPerdsc = pedido.PerDsc,
                    UsuSitppd = sitPpd,
                    UsuTipdis = pedido.TiPdis,
                    UsuRetmer = retMer,
                    UsuDatemi = datEmi,
                    UsuNecage = pedido.NecAge,
                    UsuCodemp = codemp,

                };

                _context.Usu_t009ppd.Add(modelppd);

                short seqIpd = 1;
                foreach (var item in pedido.Products)
                {
                    var props = _context.E075pros.Where(x => x.Codpro == item.Codpro)
                                                  .Select(x => new { x.Codagc, x.Codfam, x.UsuFinrec })
                                                  .FirstOrDefault();

                    T009PPI product = new T009PPI()
                    {
                        UsuNumppd = numPpd + 1,
                        UsuCodpro = item.Codpro,
                        UsuUnimed = item.Unimed,
                        UsuDesnfv = item.Desnfv,
                        UsuVlrtot = item.Vlrtot,
                        UsuPreuni = item.Preuni,
                        UsuQtdped = item.Qtdped,
                        UsuSeqipd = seqIpd,
                        UsuCodagc = props.Codagc != null ? props.Codagc : "",
                        UsuCodfam = props.Codfam != null ? props.Codfam : "",
                        UsuFinrec = props.UsuFinrec != null ? props.UsuFinrec : 0,
                        UsuCodemp = codemp
                    };
                    seqIpd++;

                    _context.Usu_t009ppi.Add(product);

                }
                
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Pre Pedido numero {numPpd + 1} enviado - status: 201");

                return StatusCode(201);
            }
            catch(Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateFromLastOrder([FromForm]CreateLastOrderViewModel lastppd)
        {

            return RedirectToAction("RenderPageCreateOrder", lastppd);
        }

        [Authorize]
        [HttpPost]
        public async Task <IActionResult> CreateLastOrder([FromForm] DataCreateLastPedido pedido)
        {
            try
            {
                DataModel data = new DataModel
                {
                    Codemp = Convert.ToInt32(User.FindFirst("codemp")!.Value),
                    Codrep = Convert.ToInt32(User.FindFirst("codusu")!.Value),
                };

                var numPpd = await _context.Usu_t009ppd.MaxAsync(x => x.UsuNumppd);
                numPpd++;
                var pedidoPpd = Convert.ToInt64(pedido.NumPpd);
                string retMer = pedido.RetMer == 1 ? "s" : "n";
                short sitPpd = (short)(pedido.SitPpd == "Não Enviado" ? 1 : 2);
                short codemp = (short)data.Codemp;
                string valor = pedido.PerDsc.Replace("%", "").Trim();
                decimal perDsc = decimal.Parse(valor, new CultureInfo("pt-BR"));
                string necAge = pedido.NecAge == 1 ? "s" : "n";


                T009PPD modelppd = new T009PPD()
                {
                    UsuNumppd = numPpd,
                    UsuObsped = pedido.ObsPed,
                    UsuCodcli = pedido.CodCli,
                    UsuCodrep = data.Codrep,
                    UsuCodcpg = pedido.CodCpg,
                    UsuPedcli = pedido.PedCli,
                    UsuDatprv = pedido.DatPrv,
                    UsuPedime = (short)pedido.PedIme,
                    UsuTipfat = (short)pedido.TipFat,
                    UsuNatope = (short)pedido.NatOpe,
                    UsuPerdsc = perDsc,
                    UsuSitppd = sitPpd,
                    UsuTipdis = (short)pedido.TipDis,
                    UsuRetmer = retMer,
                    UsuDatemi = pedido.DatEmi,
                    UsuNecage = necAge,
                    UsuCodemp = codemp,

                };

                _context.Usu_t009ppd.Add(modelppd);

                var products = await _context.Usu_t009ppi.Where(x => x.UsuNumppd == pedidoPpd && x.UsuCodemp == data.Codemp)
                                                         .ToListAsync();

                foreach (var product in products)
                {
                    T009PPI modelProducts = new T009PPI()
                    {
                        UsuNumppd = numPpd,
                        UsuSeqipd = product.UsuSeqipd,
                        UsuCodpro = product.UsuCodpro,
                        UsuQtdped = product.UsuQtdped,
                        UsuPreuni = product.UsuPreuni,
                        UsuVlrtot = product.UsuVlrtot,
                        UsuCodagc = product.UsuCodagc,
                        UsuCodfam = product.UsuCodfam,
                        UsuFinrec = product.UsuFinrec,
                        UsuDesnfv = product.UsuDesnfv,
                        UsuUnimed = product.UsuUnimed,
                        UsuCodemp = (short)data.Codemp
                    };

                    _context.Usu_t009ppi.Add(modelProducts);
                }

                await _context.SaveChangesAsync();
                
                _logger.LogInformation($"[PRE PEDIDO REPLICADO {pedido.NumPpd}] - Pre pedido numero {numPpd} gravado na base.");
                
                return RedirectToAction("RenderPageCreateOrder");
            }
            catch (Exception ex)
            {

                _logger.LogError($"{ex}");
                return BadRequest();
            }

            
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetReportCommission(string user)
        {
            return View("Commission");
        }

        [HttpGet]
        public IActionResult GetValidationFromErp(Guid guid, string numped, string codemp, string status, string? sid=null)
        {

            if(status == "200")
            {
                var from = "";
                var to = "jeferson.almeida@hiperroll.com.br";
                var subject = $"RESPOSTA REGRA 107 - ERP: Pedido {numped} gerado para empresa {codemp}"; ;
                var body = $"O pedido {numped} foi gerado com sucesso e encontra-se com status de 'Não Fechado'.";

                _sendMail.SendMail(from, to, subject, body);
                
                return Ok();
            }
            else
            {
                var from = "";
                var to = "jeferson.almeida@hiperroll.com.br";
                var subject = $"RESPOSTA REGRA 107 - ERP: Pedido não gerado para empresa {codemp}";
                var body = $"Problema na geração do pedido para empresa {codemp} - verifique: RETSID={sid}";

                _sendMail.SendMail(from, to, subject, body);

                return Ok();
            }

        }

    }
}
