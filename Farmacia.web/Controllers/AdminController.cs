using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
