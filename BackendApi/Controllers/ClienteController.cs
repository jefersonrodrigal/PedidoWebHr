using BackendApi.Database.Context;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;


namespace BackendApi.ViewsControllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMemoryCache _cache;

        public ClienteController(ApplicationContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [Authorize]
        [HttpGet("clientes/representante/{codrep}")]
        public async Task<IActionResult> GetClientesByRepresentanteAsync(int codrep)
        {
            var representante = await _context.E090rep.Where(x => x.Codrep == codrep)
                                               .Select(x => new RepresentanteModel
                                               {
                                                   NomRep = x.Nomrep,
                                                   CodRep = x.Codrep,
                                               })
                                               .FirstOrDefaultAsync();


            var clientes = await _context.E085hcls.AsNoTracking()
                                                  .Where(x => x.CodRep == codrep && x.CodEmp == 99)
                                                  .Join(_context.E085cli,
                                                        hist => hist.CodCli,
                                                        cliente => cliente.Codcli,
                                                        (hist, cliente) => new ClienteModel
                                                        {
                                                            NomCli = cliente.Nomcli,
                                                            CodCli = cliente.Codcli,
                                                            SitCli = cliente.Sitcli,
                                                            Endereço = cliente.Endcli,
                                                            Contato = cliente.Foncli,
                                                            Cgccpf = cliente.Cgccpf
                                                        }
                                                  ).ToListAsync();

            ClienteViewModel model = new ClienteViewModel()
            {
                Representante = representante!,
                Clientes = clientes
            };

            if (!_cache.TryGetValue("ApplicationCache", out ClienteViewModel? valor))
            {
                valor = model;
                _cache.Set("ApplicationCache", valor, TimeSpan.FromMinutes(3));
            }

            return View("Cliente", model);
        }

        [Authorize]
        [HttpGet("clientes/representante/cliente/{codcli}")]
        public async Task<IActionResult> GetinfoClientes(long codcli)
        {
            var cliente = await _context.E085hcls.AsNoTracking()
                                           .Where(x => x.CodCli == codcli && x.CodEmp == 99)
                                           .Join(_context.E085cli,
                                                 hist => hist.CodCli,
                                                 cliente => cliente.Codcli,
                                                 (hist, cliente) => new ClienteModel
                                                 {
                                                    CodCli = cliente.Codcli,
                                                    NomFantCli = cliente.Apecli,
                                                    UfCli = cliente.Sigufs,
                                                    Contato = cliente.Foncli,
                                                    Contato2 = cliente.Foncl2,
                                                    Cgccpf = cliente.Cgccpf,
                                                    NomCli = cliente.Nomcli,
                                                    Endereço = cliente.Endcli,
                                                    CepCli = cliente.Cepcli,
                                                    Cidade = cliente.Cidcli,
                                                    EmailCli = cliente.Emanfe,
                                                    FaxCli = cliente.Faxcli,
                                                 }
                                           ).FirstOrDefaultAsync();
            
            var data = JsonSerializer.Serialize(cliente);

            return Ok(data);
        }

    }
}
