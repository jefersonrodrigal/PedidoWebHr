using BackendApi.Database.Context;
using BackendApi.Database.Entities;
using BackendApi.Extensions;
using BackendApi.Interfaces;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendApi.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<PedidoController> _logger;
        private readonly ISendEmailService _sendMail;

        public PedidoController(ApplicationContext context, IMemoryCache cache, ILogger<PedidoController> logger, ISendEmailService sendMail)
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
                 var representante = await _context.E090rep
                .Where(x => x.Aperep == user)
                .Select(x => new RepresentanteModel
                {
                    CodRep = x.Codrep,
                    NomRep = x.Nomrep
                })
                .FirstOrDefaultAsync();

                if(representante != null)
                {
                    var query = _context.Usu_t009ppd
                                .AsNoTracking()
                                .Join(_context.Usu_t009ppi, pedido => pedido.UsuNumppd, produto => produto.UsuNumppd, (pedido, produto) => new { pedido, produto })
                                .Join(_context.E085cli, pp => pp.pedido.UsuCodcli, cliente => cliente.Codcli, (pp, cliente) => new { pp.pedido, pp.produto, cliente })
                                .Where(p => p.pedido.UsuCodrep == representante.CodRep)
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

                    var viewModel = new PainelViewModel
                    {
                        Representante = representante,
                        Produtos = produtos,
                        PaginaAtual = page,
                        PageSize = totalPages
                    };

                    return View("Painel", viewModel);
                }
                _logger.LogInformation($"Representante {user} não encontrado no sistema");
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
        public async Task<ActionResult> RenderPageCreateOrder()
        {

            var result = await _context.E090rep.Select(x => new RepresentanteModel
            {
                CodRep = x.Codrep,
                NomRep = x.Nomrep,
            }).FirstOrDefaultAsync(x => x.CodRep == Convert.ToInt32(User.FindFirstValue(ClaimTypes.UserData)));

            var numped = _context.Usu_t009ppd.Max(x => x.UsuNumppd);

            CreatePedidoViewModel model = new CreatePedidoViewModel()
            {
                Representante = result!,
                NumeroPedido = numped + 1,
            };

            return View("CreatePedidoView", model);
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
            _logger.LogInformation($"Produto {produto} pesquisado não encontrado na base");
            return NotFound("Produto não encontrado");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] DataPedidoViewModel data)
        {
            try
            {
                var numPpd = await _context.Usu_t009ppd.MaxAsync(x => x.UsuNumppd);
                DateTime.TryParse(data.DatPrv, out DateTime datPrv);
                DateTime.TryParse(data.DatEmi, out DateTime datEmi);
                string retMer = data.RetMer == "1" ? "s" : "n";
                short sitPpd = (short)(data.SitPpd == "Não Enviado" ? 1 : 2);

                T009PPD modelppd = new T009PPD()
                {
                    UsuNumppd = numPpd + 1,
                    UsuObsped = data.ObsPed,
                    UsuCodcli = data.CodCli,
                    UsuCodrep = data.CodRep,
                    UsuCodcpg = data.CodCpg,
                    UsuPedcli = data.PedCli,
                    UsuDatprv = datPrv,
                    UsuPedime = data.PedIme,
                    UsuTipfat = data.TipFat,
                    UsuNatope = data.NatOpe,
                    UsuPerdsc = data.PerDsc,
                    UsuSitppd = sitPpd,
                    UsuTipdis = data.TiPdis,
                    UsuRetmer = retMer,
                    UsuDatemi = datEmi,
                    UsuNecage = data.NecAge,
                    UsuCodemp = 99

                };

                _context.Usu_t009ppd.Add(modelppd);

                short seqIpd = 1;
                foreach (var item in data.Products)
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
                        UsuCodemp = 99
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
                var to = "";
                var subject = $"RESPOSTA REGRA 107 - ERP: Pedido {numped} gerado para empresa {codemp}"; ;
                var body = $"O pedido {numped} foi gerado com sucesso e encontra-se com status de 'Não Fechado'.";

                _sendMail.SendMail(from, to, subject, body);
                
                return Ok();
            }
            else
            {
                var from = "";
                var to = "";
                var subject = $"RESPOSTA REGRA 107 - ERP: Pedido não gerado para empresa {codemp}";
                var body = $"Problema na geração do pedido para empresa {codemp} - verifique: RETSID={sid}";

                _sendMail.SendMail(from, to, subject, body);

                return Ok();
            }

        }

    }
}
