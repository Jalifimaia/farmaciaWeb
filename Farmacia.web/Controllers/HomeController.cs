using System.Diagnostics;
using Farmacia.LogicaNegocio;
using Farmacia.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
            var usuario = UsuarioLN.IniciarSesion(model.correo,
                                                  model.contrasenia);
            if (usuario != null)
            {
                
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("RolUsuario", usuario.Rol);

                ViewBag.Mensaje = $"¡Bienvenido {usuario.Nombre}!";
                if (usuario.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (usuario.Rol == "Farmaceutico")
                {
                    return RedirectToAction("Index", "Farmaceutico");
                }
                else if (usuario.Rol == "Usuario")
                {
                    return RedirectToAction("Index", "Usuario");
                }
                else if (usuario.Rol == "Vendedor")
                {
                    return RedirectToAction("Index", "Vendedor");
                }
                else if (usuario.Rol == "Gerente")
                {
                    return RedirectToAction("Index", "Gerente");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                //return View();
            }
            else
            {
                ViewBag.Mensaje = "Correo o contraseña incorrectos.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            // Limpia la variable que simula el nombre del usuario logueado
            // O si usas TempData para un mensaje de bienvenida de una sola vez
            // TempData.Remove("NombreUsuario");
            return RedirectToAction("Index", "Home");


        }
    }
}