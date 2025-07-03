using Farmacia.Entidades;
using Farmacia.LogicaNegocio;
using Farmacia.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Farmacia.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var usuarioLN = new UsuarioLN();
            var usuario = usuarioLN.IniciarSesion(model.correo, model.contrasenia);


            if (usuario != null)
            {
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("RolUsuario", usuario.Rol.Nombre);

                switch (usuario.Rol.Nombre)
                {
                    case "Administrador": return RedirectToAction("Index", "Admin");
                    case "Farmaceutico": return RedirectToAction("Index", "Farmaceutico");
                    case "Vendedor": return RedirectToAction("Index", "Vendedor");
                    case "Gerente": return RedirectToAction("Index", "Gerente");
                    default: return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Mensaje = "Correo o contraseña incorrectos.";
            return View();
        }


        [HttpPost]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");


        }
    }
}