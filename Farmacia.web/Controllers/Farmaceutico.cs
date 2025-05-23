using Microsoft.AspNetCore.Mvc;

namespace Farmacia.web.Controllers
{
    public class Farmaceutico : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
