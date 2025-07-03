using Microsoft.AspNetCore.Mvc;
using Farmacia.LogicaNegocio;
using Farmacia.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Farmacia.web.Controllers
{
    public class AdminController : Controller
    {
   
        private readonly UsuarioLN usuarioLN = new UsuarioLN();
        private readonly RolLn rolLN = new RolLn();

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Esto carga Views/Admin/Index.cshtml
        }

        public IActionResult Listar()
        {
            var usuarios = usuarioLN.ObtenerTodos();
            return View(usuarios);
        }

        // Mostrar formulario para crear usuario
        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Roles = new List<SelectListItem>
    {
        new SelectListItem { Text = "Administrador", Value = "Administrador" },
        new SelectListItem { Text = "Farmacéutico", Value = "Farmacéutico" },
        new SelectListItem { Text = "Gerente", Value = "Gerente" },
        new SelectListItem { Text = "Vendedor", Value = "Vendedor" }
    };

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            try
            {
                usuarioLN.CrearUsuario(usuario);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }




        // Mostrar formulario para editar usuario
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = usuarioLN.ObtenerPorId(id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // Procesar edición de usuario
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            string mensaje = usuarioLN.ActualizarUsuario(usuario);
            TempData["Mensaje"] = mensaje;
            return RedirectToAction("Listar");
        }

        // Eliminar usuario
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            string mensaje = usuarioLN.EliminarUsuario(id);
            TempData["Mensaje"] = mensaje;
            return RedirectToAction("Listar");
        }

        // Buscar usuarios
        [HttpGet]
        public IActionResult Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                TempData["Mensaje"] = "Ingrese un criterio para buscar.";
                return RedirectToAction("Listar");
            }

            var usuarios = usuarioLN.BuscarUsuarios(criterio);
            if (usuarios.Count == 0)
                TempData["Mensaje"] = "No se encontraron usuarios.";

            return View("Listar", usuarios);
        }
    }


}




  
