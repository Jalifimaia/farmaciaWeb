using Microsoft.AspNetCore.Mvc;

namespace Farmacia.web.Controllers
{
    public class Vendedor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
