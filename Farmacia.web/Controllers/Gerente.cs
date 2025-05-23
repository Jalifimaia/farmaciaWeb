using Microsoft.AspNetCore.Mvc;

namespace Farmacia.web.Controllers
{
    public class Gerente : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
