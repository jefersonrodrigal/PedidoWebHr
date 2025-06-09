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

                // Join de pedidos, produtos e clientes com paginação no banco
                var queryProdutos = from pedido in _context.Usu_t009ppd
                                    join produto in _context.Usu_t009ppi on pedido.UsuNumppd equals produto.UsuNumppd
                                    join cliente in _context.E085cli on pedido.UsuCodcli equals cliente.Codcli
                                    where pedido.UsuCodrep == CodRep
                                    orderby pedido.UsuNumppd descending
                                    select new PedidoProdutoModel
                                    {
                                        Numppd = produto.UsuNumppd,
                                        CodPro = produto.UsuCodpro,
                                        Unimed = produto.UsuUnimed,
                                        PreUni = produto.UsuPreuni,
                                        Quantidade = produto.UsuQtdped,
                                        DescPro = produto.UsuDesnfv,
                                        NomCli = cliente.Nomcli,
                                        CodCli = cliente.Codcli,
                                        NumNfv = pedido.UsuNumnfv,
                                        DateEmi = pedido.UsuDatemi
                                    };

                var totalItems = await queryProdutos.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                var produtosPaginados = await queryProdutos
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var viewModel = new PainelViewModel
                {
                    Representante = representante,
                    Produtos = produtosPaginados,
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
