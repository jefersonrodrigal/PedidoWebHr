using BackendApi.Database.Context;
using BackendApi.Database.Entities;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BackendApi.ApiControllers
{

    public class PedidoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PedidoController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("api/pedidos/{CodRep}")]
        public async Task<ActionResult<T009PPD>> GetPedidosAsync(int CodRep)
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
                                                        .Select(x => new PedidoModel
                                                        {
                                                            NumPpd = x.UsuNumppd,
                                                            DatEmi = x.UsuDatemi
                                                        })
                                                        .ToListAsync();

                var dataProdutos = await _context.Usu_t009ppi.AsNoTracking()
                                                         .Select(x => new ProdutoModel
                                                         {
                                                             NumPpd = x.UsuNumppd,
                                                             CodPro = x.UsuCodpro,
                                                             Unimed = x.UsuUnimed
                                                         })
                                                         .ToListAsync();
                var produtos = from pedido in pedidos
                               join produto in dataProdutos
                               on pedido.NumPpd equals produto.NumPpd
                               select new PedidoProdutoModel{Numppd = produto.NumPpd, CodPro = produto.CodPro, Unimed = produto.Unimed };


                PainelViewModel viewmodel = new PainelViewModel
                {
                    Representante = representante,
                    Pedidos = pedidos,
                    Produtos = produtos
                };

                return Ok(viewmodel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao buscar pedidos", Error = ex.Message });
            }
        }
    }
}
