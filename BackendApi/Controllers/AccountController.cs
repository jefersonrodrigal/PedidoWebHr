using BackendApi.Database.Context;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackendApi.ViewsControllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromForm] LoginViewModel user, int page=1, int pageSize=5)
        {
            if(ModelState.IsValid)
            {

                var repres = await _context.E090rep.FirstOrDefaultAsync(x => x.Aperep == user.Username && x.Senrep == user.Password);

                if (repres != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username!),
                        new Claim(ClaimTypes.Role, "Representante"),
                        new Claim(ClaimTypes.NameIdentifier, repres.Nomrep),
                        new Claim(ClaimTypes.UserData, Convert.ToString(repres.Codrep))
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    var url = Url.RouteUrl("pedidos", new { user = repres.Aperep }) ?? "/erro";

                    return Redirect(url);
                }
            }

            return BadRequest("Usuario ou senha invalidos");
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
