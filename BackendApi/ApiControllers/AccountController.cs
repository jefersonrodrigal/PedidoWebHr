using BackendApi.Database.Context;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.ApiControllers
{
    public class AccountController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost("/login")]
        public async Task<ActionResult> Login([FromBody] UsuarioViewModel user)
        {
            if (ModelState.IsValid)
            {
                var reper = await _context.E090rep.FirstOrDefaultAsync(x => x.Aperep == user.Username);

                if (reper != null)
                {
                    return Ok("Representante registrado");
                }
            }

            return Ok();
        }
    }
}
