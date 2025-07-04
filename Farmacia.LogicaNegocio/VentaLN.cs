using Farmacia.Datos;

namespace Farmacia.LogicaNegocio
{
    public class VentaLN
    {
        private VentaDAL dal = new VentaDAL();

        public List<(string NombreMedicamento, int CantidadVendida)> ObtenerReporteVentas()
        {
            return dal.ObtenerReporteVentas();
        }
    }
}
