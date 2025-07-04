using Microsoft.AspNetCore.Mvc;
using Farmacia.Entidades;
using Farmacia.LogicaNegocio;

namespace Farmacia.web.Controllers
{
    public class GerenteController : Controller
    {
        private MedicamentoLN medicamentoLN = new MedicamentoLN();

        public IActionResult Index()
        {
            return View(); // Menu básico del gerente
        }

        [HttpGet]
        public IActionResult ReporteInventario(string orden = "alfabetico")
        {
            var lista = medicamentoLN.ObtenerMedicamentos();

            if (orden == "cantidad")
                lista = lista.OrderByDescending(m => m.Stock).ToList();
            else
                lista = lista.OrderBy(m => m.Nombre).ToList();

            return View(lista);
        }

        [HttpGet]
        public IActionResult ReporteAlertas(string tipo = "ambos")
        {
            var lista = medicamentoLN.ObtenerMedicamentos();
            var fechaHoy = DateTime.Today;

            var criticos = lista.Where(m => m.Stock <= 5).ToList();
            var vencenPronto = lista.Where(m => m.Fecha_Vencimiento <= fechaHoy.AddDays(30)).ToList();

            List<Medicamento> resultado = new();

            if (tipo == "stock")
                resultado = criticos;
            else if (tipo == "vencimiento")
                resultado = vencenPronto;
            else
                resultado = criticos.Union(vencenPronto).Distinct().ToList();

            return View(resultado);
        }
        [HttpGet]
        public IActionResult ReporteVentas()
        {
            VentaLN ventaLN = new VentaLN();
            var reporte = ventaLN.ObtenerReporteVentas();
            return View(reporte);
        }

    }
}
