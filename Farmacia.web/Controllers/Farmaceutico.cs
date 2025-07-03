using Farmacia.DAL;
using Farmacia.Entidades;
using Farmacia.LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.web.Controllers
{
    public class FarmaceuticoController : Controller
    {
        private MedicamentoLN logica = new MedicamentoLN();

        public IActionResult Index(bool mostrarTabla = false)
        {
            var medicamentos = logica.ObtenerMedicamentos();
            ViewBag.MostrarTabla = mostrarTabla;
            return View("Index", medicamentos);
        }



        [HttpPost]
        public IActionResult RegistrarMedicamento(string Nombre, int Precio, int Stock, DateTime Fecha_Vencimiento)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || Precio <= 0 || Stock < 0)
            {
                ViewBag.Mensaje = "Se encuentran campos sin completar.";
                return RedirectToAction("Index");
            }

            var nuevoMed = new Medicamento
            {

                Nombre = Nombre,
                Precio = Precio,
                Stock = Stock,
                Fecha_Vencimiento = Fecha_Vencimiento
            };

            logica.RegistrarMedicamento(nuevoMed);
            TempData["Mensaje"] = "¡Medicamento registrado correctamente (modo prueba)!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarMedicamento(int id)
        {
            logica.EliminarMedicamento(id);
            TempData["Mensaje"] = "Medicamento eliminado.";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult BuscarMedicamentos(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                TempData["Mensaje"] = "Debe ingresar un valor para buscar.";
                return RedirectToAction("Index");
            }

            var medicamentos = logica.ObtenerMedicamentos();

            var resultados = medicamentos.Where(m =>
                (!string.IsNullOrEmpty(m.Nombre) && m.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)) ||
                m.Id_Medicamento.ToString() == criterio
            ).ToList();

            if (resultados.Count == 0)
            {
                TempData["Mensaje"] = "No se encontraron medicamentos que coincidan con el criterio.";
            }

            ViewBag.MostrarTabla = true; // Mostrar la tabla 
            return View("Index", resultados);
        }

        public IActionResult TablaMedicamentos()
        {
            var medicamentos = logica.ObtenerMedicamentos();
            return PartialView("_TablaMedicamentos", medicamentos);
        }

        [HttpPost]
        public IActionResult ActualizarMedicamento(Medicamento m)
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            dal.Actualizar(m);

            TempData["Mensaje"] = "Medicamento actualizado correctamente 💊✨";
            return RedirectToAction("Index", new { mostrarTabla = true });
        }


    }
}
