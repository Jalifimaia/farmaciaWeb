using Farmacia.Entidades;
using Farmacia.LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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
        public IActionResult RegistrarCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Mensaje = "Error. Verifique los campos.";
                return View(cliente);
            }

            bool exito = clienteLN.RegistrarCliente(cliente);

            if (exito)
            {
                TempData["Mensaje"] = "Cliente registrado con éxito.";
                return RedirectToAction("RegistrarCliente");
            }
            else
            {
                ViewBag.Mensaje = "No se pudo registrar el cliente.";
                return View(cliente);
            }
        }


        [HttpGet]
        public IActionResult BuscarCliente()
        {
            var clientes = clienteLN.BuscarClientes(""); // Traer todos al inicio o los primeros
            return View(clientes);
        }

        [HttpPost]
        public IActionResult BuscarCliente(string criterio)
        {
            var clientes = clienteLN.BuscarClientes(criterio);
            if (clientes.Count == 0)
                ViewBag.Mensaje = "No se encontraron clientes.";

            return View(clientes); // Retornar la misma vista con la lista filtrada
        }


    }
}


