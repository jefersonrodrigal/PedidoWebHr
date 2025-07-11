using BackendApi.Database.Context;
using BackendApi.Interfaces;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.ViewsControllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthenticationService _authService;

        public AccountController(ApplicationContext context, ILogger<AccountController> logger, IAuthenticationService authService)
        {
            _context = context;
            _logger = logger;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromForm] UserViewModel user, int page=1, int pageSize=5)
        {
            
            if(ModelState.IsValid)
            {
                var repres = await _context.E090rep.FirstOrDefaultAsync(x => x.Aperep == user.Username && x.Senrep == user.Password);

                if (repres != null)
                {
                    user.Role = "Representante";
                    user.CodUsu = repres.Codrep;

                    var token = _authService.TokenGenerate(user);

                    var cookie = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddMinutes(30)
                    };

                    Response.Cookies.Append("jwtToken", token, cookie);
                    var url = Url.RouteUrl("pedidos", new { user = repres.Aperep }) ?? "/erro";
                    return Redirect(url);
                }
            }

            return BadRequest("Usuario ou senha invalidos");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwtToken");
            return Redirect("/");
        }
    }
}
