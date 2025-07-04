using Farmacia.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Farmacia.web.Models
{
    public class RegistrarVentaViewModel
    {
        public int Id_Cliente { get; set; }
        public int Id_Medicamento { get; set; }
        public int Cantidad { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public List<SelectListItem> Clientes { get; set; }
        public List<SelectListItem> Medicamentos { get; set; }
    }


}
