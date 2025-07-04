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

        public List<Venta> ListarVentasConDetalles()
        {
            // Llamar al SP sin parámetros
            DataTable dt = conexion.LeerPorStoreProcedure("sp_ListarVentasConDetalles", null);

            // Diccionario para agrupar detalles por venta
            var ventasDict = new Dictionary<int, Venta>();

            foreach (DataRow row in dt.Rows)
            {
                int idVenta = Convert.ToInt32(row["Id_Venta"]);

                // Si la venta no existe en el diccionario, crearla y agregarla
                if (!ventasDict.ContainsKey(idVenta))
                {
                    Venta venta = new Venta
                    {
                        Id_Venta = idVenta,
                        Id_Cliente = Convert.ToInt32(row["Id_Cliente"]),
                        Id_Vendedor = Convert.ToInt32(row["Id_Vendedor"]),
                        Monto_Total = Convert.ToSingle(row["Monto_Total"]),
                        Detalles = new List<DetalleVenta>()
                    };
                    ventasDict.Add(idVenta, venta);
                }

                // Crear el detalle de venta
                DetalleVenta detalle = new DetalleVenta
                {
                    Id_Detalle = Convert.ToInt32(row["Id_Detalle"]),
                    Id_Medicamento = Convert.ToInt32(row["Id_Medicamento"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Precio_Unitario = row["Precio_Unitario"] == DBNull.Value ? 0 : Convert.ToInt32(row["Precio_Unitario"]),
                    SubTotal = Convert.ToSingle(row["SubTotal"])
                };

                // Agregar el detalle a la venta correspondiente
                ventasDict[idVenta].Detalles.Add(detalle);
            }

            // Devolver la lista de ventas con sus detalles
            return ventasDict.Values.ToList();
        }


    }
}

