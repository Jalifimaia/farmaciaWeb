using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Datos;
using Farmacia.Entidades;

namespace Farmacia.LogicaNegocio
{ 
   public class VentaLN
    {
        private VentaDAL datos = new VentaDAL();

        public void RegistrarVentaCompleta(Venta venta, List<DetalleVenta> detalles)
        {
            datos.RegistrarVentaConSP(venta, detalles);
        }

    }


}
