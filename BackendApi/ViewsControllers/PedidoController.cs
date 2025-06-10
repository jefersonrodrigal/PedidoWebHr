using BackendApi.Database.Context;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.ViewsControllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationContext _context;


        public PedidoController(ApplicationContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("/painel/{CodRep}")]
        public async Task<IActionResult> Painel(int CodRep, int page=1, int pageSize=10)
        {
            try
            {
                 var representante = await _context.E090rep
                .Where(x => x.Codrep == CodRep)
                .Select(x => new RepresentanteModel
                {
                    CodRep = x.Codrep,
                    NomRep = x.Nomrep
                })
                .FirstOrDefaultAsync();

             var query = from pedido in _context.Usu_t009ppd
                         join produto in _context.Usu_t009ppi on pedido.UsuNumppd equals produto.UsuNumppd
                         join cliente in _context.E085cli on pedido.UsuCodcli equals cliente.Codcli
                         where pedido.UsuCodrep == CodRep
                         group new { pedido, produto, cliente }  by produto.UsuNumppd into g
                         orderby g.First().pedido.UsuDatemi descending
                         select new PedidoModel
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
                            })
                            .ToList()
                                
                         };

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

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
