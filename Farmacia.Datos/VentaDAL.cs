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

        public bool RegistrarVenta(Venta venta, List<DetalleVenta> detalles)
        {
           ;

            // Paso 1: Armar DataTable para el parámetro tipo tabla
            DataTable tablaDetalle = new DataTable();
            tablaDetalle.Columns.Add("Cantidad", typeof(int));
            tablaDetalle.Columns.Add("Precio_Unitario", typeof(float));
            tablaDetalle.Columns.Add("SubTotal", typeof(float));
            tablaDetalle.Columns.Add("Id_Medicamento", typeof(int));

            foreach (var d in detalles)
            {
                tablaDetalle.Rows.Add(d.Cantidad, d.Precio_Unitario, d.SubTotal, d.Id_Medicamento);
            }

            // Paso 2: Armar parámetros
            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Id_Vendedor", venta.Id_Vendedor),
        conexion.crearParametro("@Id_Cliente", venta.Id_Cliente),
        conexion.crearParametro("@Monto_Total", venta.Monto_Total),
        new SqlParameter
        {
            ParameterName = "@DetalleVenta",
            SqlDbType = SqlDbType.Structured,
            TypeName = "DetalleVentaTipo", // IMPORTANTE que coincida con el nombre en SQL Server
            Value = tablaDetalle
        }
            };

            // Paso 3: Ejecutar el SP
            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_RegistrarVentaCompleta", parametros);
            return filasAfectadas > 0;
        }
        public List<(string NombreMedicamento, int CantidadVendida)> ObtenerReporteVentas()
        {
            string consulta = @"
        SELECT m.Nombre, SUM(dv.Cantidad) AS CantidadVendida
        FROM DetalleVenta dv
        INNER JOIN Medicamento m ON m.Id_Medicamento = dv.Id_Medicamento
        GROUP BY m.Nombre
        ORDER BY CantidadVendida DESC";

            var tabla = conexion.LeerPorComando(consulta);

            List<(string, int)> lista = new List<(string, int)>();

            foreach (DataRow fila in tabla.Rows)
            {
                string nombre = fila["Nombre"].ToString();
                int cantidad = Convert.ToInt32(fila["CantidadVendida"]);
                lista.Add((nombre, cantidad));
            }

            return lista;
        }


    }

}
