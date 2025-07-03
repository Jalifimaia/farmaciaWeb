using Farmacia.Entidades;
using Farmacia.LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.web.Controllers
{
    public class Vendedor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private ClienteLN clienteLN = new ClienteLN();

        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    clienteLN.RegistrarCliente(cliente);
                    TempData["Mensaje"] = "Cliente registrado correctamente.";
                    return RedirectToAction("RegistrarCliente");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al registrar cliente: " + ex.Message);
                }
            }
            return View(cliente);
        }


    }
}

