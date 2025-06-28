using BackendApi.Database.Context;
using BackendApi.Extensions;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace BackendApi.Controllers
{
    public class PedidoController(ApplicationContext context, IMemoryCache cache) : Controller
    {
        private readonly ApplicationContext _context = context;
        private readonly IMemoryCache _cache = cache;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PedidoRepresentanteAsync(string user, int page=1, int pageSize=2)
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

                    if (!_cache.TryGetValue("ApplicationCache", out PainelViewModel? valor))
                    {
                        valor = viewModel;
                        _cache.Set("ApplicationCache", valor, TimeSpan.FromSeconds(60));
                    }

                    return View("Painel", viewModel);
                }
                return NotFound("Representante não encontrado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PegarUltimosPedidos(BuscaPedidoViewModel request)
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

            return BadRequest("Dado Invalido para pesquisa");
        }

        [Authorize]
        [HttpGet]
        public ActionResult RenderPageLancamentoPedido()
        {

            var result = _context.E090rep.Select(x => new RepresentanteModel
            {
                CodRep = x.Codrep,
                NomRep = x.Nomrep,
            }).FirstOrDefault(x => x.CodRep == Convert.ToInt32(User.FindFirstValue(ClaimTypes.UserData)));

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
        public IActionResult GetClientFormGeneratePerdido(string cliente)
        {
            var query = _context.E085cli.FirstOrDefault(x => x.Cgccpf == Convert.ToInt64(cliente));

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
                FaxCli =    query.Faxcli,
                InscEstadual = query.Insest,
                Bairro = query.Baicli
            };

            return Ok(dataClient);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProductFromFormToGenerateOrder(string produto)
        {
            var query = _context.E075pros.FirstOrDefault(x => x.Codpro == produto);

            ProdutoModel product = new ProdutoModel()
            {
                CodPro = query.Codpro,
                DescPro = query.Despro,
                Unimed = query.Unimed,
            };

            return Ok(product);
        }
    }
}
