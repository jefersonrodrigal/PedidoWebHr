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
        public async Task<IActionResult> Painel(int CodRep)
        {
            try
            {
                var representante = await _context.E090rep.Where(x => x.Codrep == CodRep)
                    .Select(x => new RepresentanteModel
                    {
                        CodRep = x.Codrep,
                        NomRep = x.Nomrep
                    })
                    .FirstOrDefaultAsync();

                var pedidos = await _context.Usu_t009ppd.Where(x => x.UsuCodrep == CodRep)
                    .AsNoTracking()
                    .Select(x => new PedidoModel
                    {
                        NumPpd = x.UsuNumppd,
                        DatEmi = x.UsuDatemi,
                        CodCli = x.UsuCodcli,
                        NumNfv = x.UsuNumnfv
                    }).ToListAsync();

                var dataProdutos = await _context.Usu_t009ppi.AsNoTracking()
                    .Select(x => new ProdutoModel
                    {
                        NumPpd = x.UsuNumppd,
                        CodPro = x.UsuCodpro,
                        Unimed = x.UsuUnimed,
                        PreUni = x.UsuPreuni,
                        Quantidade = x.UsuQtdped,
                        DescPro = x.UsuDesnfv,
                    }).ToListAsync();

                var dataclientes = await _context.E085cli.AsNoTracking()
                    .Select(x => new ClienteModel
                    {
                        CodCli = x.Codcli,
                        NomCli = x.Nomcli
                    }).ToListAsync();

                var clientes = from pedido in pedidos
                               join cliente in dataclientes
                               on pedido.CodCli equals cliente.CodCli
                               select new PedidoClienteModel
                               {
                                   CodCli = pedido.CodCli,
                                   Numped = pedido.NumPpd,
                                   NomCli = cliente.NomCli
                               };

                var produtos = from pedido in pedidos
                               join produto in dataProdutos
                               on pedido.NumPpd equals produto.NumPpd
                               select new PedidoProdutoModel
                               {
                                   Numppd = produto.NumPpd,
                                   CodPro = produto.CodPro,
                                   Unimed = produto.Unimed,
                                   PreUni = produto.PreUni,
                                   Quantidade = produto.Quantidade,
                                   DescPro = produto.DescPro,
                               };

                var data = produtos.ToList();

                PainelViewModel viewmodel = new PainelViewModel
                {
                    Representante = representante,
                    Pedidos = pedidos,
                    Produtos = data,
                    Cliente = clientes,
                };
                return View(viewmodel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
