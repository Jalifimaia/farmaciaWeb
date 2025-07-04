using Farmacia.Entidades;

namespace Farmacia.web.Models
{
    public class VentaConDetallesViewModel
    {
        public int Id_Venta { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Vendedor { get; set; }
        public float Monto_Total { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }

}
