﻿using BackendApi.Database.Context;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text.Json;


namespace BackendApi.ViewsControllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationContext _context;

        public ClienteController(ApplicationContext context, IMemoryCache cache)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClientesByRepresentanteAsync(string user)
        {
            var representante = await _context.E090rep.Where(x => x.Aperep == user)
                                               .Select(x => new RepresentanteModel
                                               {
                                                   NomRep = x.Nomrep,
                                                   CodRep = x.Codrep,
                                               })
                                               .FirstOrDefaultAsync();


            if(representante != null)
            {

                var clientes = await _context.E085hcls.AsNoTracking()
                    .Where(x => x.CodRep == representante.CodRep && x.CodEmp == 99)
                    .Join(_context.E085cli.OrderByDescending(x => x.Datcad)
                    .Where(x => x.Sitcli == "A"),
                          hist => hist.CodCli,
                          cliente => cliente.Codcli,
                          (hist, cliente) => new ClienteModel
                          {
                              NomCli = cliente.Nomcli,
                              CodCli = cliente.Codcli,
                              SitCli = cliente.Sitcli,
                              Endereco = cliente.Endcli,
                              Contato = cliente.Foncli,
                              Cgccpf = cliente.Cgccpf
                          })
                    .ToListAsync();




                ClienteViewModel model = new ClienteViewModel()
                {
                    Representante = representante!,
                    Clientes = clientes,
                };

                return View("Cliente", model);
            }
            
            return NotFound("Representante Não encontrado");

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetinfoClientesAsync(long codcli)
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
                                                    Endereco = cliente.Endcli,
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
