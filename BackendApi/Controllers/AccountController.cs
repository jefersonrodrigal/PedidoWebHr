using BackendApi.Database.Context;
using BackendApi.Interfaces;
using BackendApi.Models;
using BackendApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
                    UserAuthModel authUser = new UserAuthModel()
                    {
                        Username = user.Username,
                        CodUsu = Convert.ToString(repres.Codrep),
                        Codemp = user.Segment == "Plastico" ? "99" : "98",
                        Segment = user.Segment,
                        Role = "Representante"
                    };

                    var token = _authService.TokenGenerate(authUser);

                    var cookie = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddMinutes(30)
                    };
                   
                    Response.Cookies.Append("jwtToken", token, cookie);

                    var url = Url.RouteUrl("pedidos", new { user = user.Username}) ?? "/erro";
                    _logger.LogInformation($"Login realizado com sucesso {user.Username}");
                    return Redirect(url);
                }
            }
            
            _logger.LogInformation($"Usuario ou senha invalidos - {user.Username}");
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
