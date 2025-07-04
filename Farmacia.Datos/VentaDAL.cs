using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Farmacia.Entidades;

namespace Farmacia.Datos
{
    public class VentaDAL
    {
        private Conexion conexion = new Conexion();

        public void RegistrarVentaConSP(Venta venta, List<DetalleVenta> detalles)
        {
            var tablaDetalle = new DataTable();
            tablaDetalle.Columns.Add("Id_Medicamento", typeof(int));
            tablaDetalle.Columns.Add("Cantidad", typeof(int));
            tablaDetalle.Columns.Add("Precio_Unitario", typeof(int));
            tablaDetalle.Columns.Add("SubTotal", typeof(float)); // si usás int también sirve

            foreach (var d in detalles)
            {
                tablaDetalle.Rows.Add(d.Id_Medicamento, d.Cantidad, d.Precio_Unitario, d.SubTotal);
            }

            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Id_Cliente", venta.Id_Cliente),
        conexion.crearParametro("@Id_Vendedor", venta.Id_Vendedor),
        conexion.crearParametro("@Monto_Total", venta.Monto_Total),
        new SqlParameter
        {
            ParameterName = "@DetalleVenta",
            SqlDbType = SqlDbType.Structured,
            TypeName = "DetalleVentaTipo",
            Value = tablaDetalle
        }

            };
           


            conexion.EscribirPorStoreProcedure("sp_RegistrarVentaCompleta", parametros);
        }


    }
}

