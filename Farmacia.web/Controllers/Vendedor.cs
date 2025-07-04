using Farmacia.Entidades;
using Farmacia.LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Farmacia.web.Models;
using Microsoft.AspNetCore.Http;
using Farmacia.web.Helpers;
using System.Data;
using Farmacia.Datos;


namespace Farmacia.web.Controllers
{
    public class Vendedor : Controller
    {



        private MedicamentoLN medicamentoLN = new MedicamentoLN();
        private VentaLN ventaLN = new VentaLN();
        private const string SESSION_DETALLES = "DetallesVenta";
        private int ObtenerIdUsuarioLogueado()
        {

            return 1;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ClienteLN clienteLN = new ClienteLN();

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



        [HttpGet]
        public IActionResult RegistrarVenta()
        {
            var model = new RegistrarVentaViewModel
            {
                Clientes = clienteLN.ObtenerTodos().Select(c => new SelectListItem
                { Value = c.Id_Cliente.ToString(), Text = c.Nombre + " " + c.Apellido }).ToList(),

                Medicamentos = medicamentoLN.ObtenerMedicamentos().Select(m => new SelectListItem
                { Value = m.Id_Medicamento.ToString(), Text = m.Nombre }).ToList(),

                Detalles = new List<DetalleVenta>()
            };

            // Inicializar sesión para detalles vacía
            HttpContext.Session.Set(SESSION_DETALLES, new List<DetalleVenta>());

            return View(model);
        }

        [HttpPost]
        public IActionResult RegistrarVenta(RegistrarVentaViewModel model, string action)
        {
            var detalles = HttpContext.Session.Get<List<DetalleVenta>>(SESSION_DETALLES) ?? new List<DetalleVenta>();

            if (action == "Agregar")
            {
                var medicamento = medicamentoLN.ObtenerPorId(model.Id_Medicamento);

                if (medicamento == null)
                {
                    ModelState.AddModelError("", "Medicamento no encontrado.");
                }
                else
                {
                    var detalle = new DetalleVenta
                    {
                        Id_Medicamento = medicamento.Id_Medicamento,
                        Cantidad = model.Cantidad,
                        Precio_Unitario = medicamento.Precio,
                        SubTotal = medicamento.Precio * model.Cantidad
                    };

                    detalles.Add(detalle);
                    HttpContext.Session.Set(SESSION_DETALLES, detalles);
                }

                // Re-cargar dropdowns y detalles
                model.Clientes = clienteLN.ObtenerTodos().Select(c => new SelectListItem
                { Value = c.Id_Cliente.ToString(), Text = c.Nombre + " " + c.Apellido }).ToList();

                model.Medicamentos = medicamentoLN.ObtenerMedicamentos().Select(m => new SelectListItem
                { Value = m.Id_Medicamento.ToString(), Text = m.Nombre }).ToList();

                model.Detalles = detalles;

                return View(model);
            }
            else if (action == "Finalizar")

            {
                if (detalles.Count == 0)
                {
                    ModelState.AddModelError("", "Debe agregar al menos un medicamento.");
                }
                else
                {
                    var venta = new Venta
                    {
                        Id_Cliente = model.Id_Cliente,
                        Id_Vendedor = Convert.ToInt32(HttpContext.Session.GetString("Id_Usuario")), // o como obtengas el usuario
                        Monto_Total = (int)detalles.Sum(d => d.SubTotal),
                       
                    };

                    // Crear DataTable para pasar al SP
                    DataTable dtDetalles = new DataTable();
                    dtDetalles.Columns.Add("Cantidad", typeof(int));
                    dtDetalles.Columns.Add("Precio_Unitario", typeof(float));
                    dtDetalles.Columns.Add("SubTotal", typeof(float));
                    dtDetalles.Columns.Add("Id_Medicamento", typeof(int));

                    foreach (var d in detalles)
                    {
                        dtDetalles.Rows.Add(d.Cantidad, d.Precio_Unitario, d.SubTotal, d.Id_Medicamento);
                    }

                    // Llamar al método en la capa lógica que llama al SP
                    ventaLN.RegistrarVentaCompleta(venta, detalles);

                    // Limpiar la sesión
                    HttpContext.Session.Remove(SESSION_DETALLES);

                    ViewBag.MensajeExito = " La venta fue registrada correctamente.";

                    model = new RegistrarVentaViewModel
                    {
                        Clientes = clienteLN.ObtenerTodos().Select(c => new SelectListItem
                        {
                            Value = c.Id_Cliente.ToString(),
                            Text = c.Nombre + " " + c.Apellido
                        }).ToList(),

                        Medicamentos = medicamentoLN.ObtenerMedicamentos().Select(m => new SelectListItem
                        {
                            Value = m.Id_Medicamento.ToString(),
                            Text = m.Nombre
                        }).ToList(),

                        Detalles = new List<DetalleVenta>() // Limpiar detalles para nueva venta
                    };

                    return View(model);

                }
            }

            // Si llegamos acá, recargar dropdowns y detalles
            model.Clientes = clienteLN.ObtenerTodos().Select(c => new SelectListItem
            { Value = c.Id_Cliente.ToString(), Text = c.Nombre + " " + c.Apellido }).ToList();

            model.Medicamentos = medicamentoLN.ObtenerMedicamentos().Select(m => new SelectListItem
            { Value = m.Id_Medicamento.ToString(), Text = m.Nombre }).ToList();

            model.Detalles = detalles;

            return View(model);
        }


        [HttpGet]
        public IActionResult ListarCliente()
        {
            var clientes = clienteLN.ObtenerTodos();
            return View(clientes);
        }


        

        [HttpGet]
        public IActionResult ListarVentas()
        {
            var ventas = ventaLN.ListarVentasConDetalles(); 
            return View(ventas);
        }



    }



}



