using BackendApi.Database.Context;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BackendApi.ViewsControllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMemoryCache _cache;

        public PedidoController(ApplicationContext context, IMemoryCache cache)
        {
            _cache = cache;
            _context = context;
        }

        [Authorize]
        [HttpGet("pedidos/representante/{CodRep}")]
        public async Task<IActionResult> PedidoRepresentanteAsync(int codRep, int page=1, int pageSize=5)
        {
            try
            {
                 var representante = await _context.E090rep
                .Where(x => x.Codrep == codRep)
                .Select(x => new RepresentanteModel
                {
                    CodRep = x.Codrep,
                    NomRep = x.Nomrep
                })
                .FirstOrDefaultAsync();

                var query = _context.Usu_t009ppd
                            .Join(_context.Usu_t009ppi, pedido => pedido.UsuNumppd, produto => produto.UsuNumppd, (pedido, produto) => new { pedido, produto })
                            .Join(_context.E085cli, pp => pp.pedido.UsuCodcli, cliente => cliente.Codcli, (pp, cliente) => new { pp.pedido, pp.produto, cliente })
                            .Where(p => p.pedido.UsuCodrep == codRep)
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
                                      Quantidade = p.produto.UsuQtdped
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


    }
}
