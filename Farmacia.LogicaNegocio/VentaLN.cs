
﻿using System;
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
        private VentaDAL dal = new VentaDAL();

        public void RegistrarVentaCompleta(Venta venta, List<DetalleVenta> detalles)
        {
            datos.RegistrarVentaConSP(venta, detalles);
        }


        public List<(string NombreMedicamento, int CantidadVendida)> ObtenerReporteVentas()
        {
            return dal.ObtenerReporteVentas();
        }
    }
}

