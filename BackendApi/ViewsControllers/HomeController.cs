using Microsoft.AspNetCore.Mvc;

namespace BackendApi.ViewsControllers
{
    public class HomeController : Controller
    {
        [HttpGet("/home")]
        public ActionResult Home()
        {
            return RedirectToAction("/api/pedidos");
        }
        
    }
}
