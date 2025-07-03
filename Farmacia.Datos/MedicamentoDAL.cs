using DAL;
using Farmacia.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Farmacia.DAL
{
    public class MedicamentoDAL
    {
        private Conexion conexion = new Conexion();

        public List<Medicamento> ObtenerTodos()
        {
            List<Medicamento> lista = new List<Medicamento>();

            string consulta = "SELECT * FROM Medicamento";

            DataTable tabla = conexion.LeerPorComando(consulta);

            foreach (DataRow fila in tabla.Rows)
            {
                Medicamento m = new Medicamento
                {
                    Id_Medicamento = Convert.ToInt32(fila["Id_Medicamento"]),
                    Nombre = fila["Nombre"].ToString(),
                    Precio = Convert.ToInt32(fila["Precio"]),
                    Stock = Convert.ToInt32(fila["Stock"]),
                    Fecha_Vencimiento = fila["Fecha_Vencimiento"] != DBNull.Value
                        ? Convert.ToDateTime(fila["Fecha_Vencimiento"])
                        : DateTime.MinValue
                };

                lista.Add(m);
            }

            return lista;
        }

        public void Agregar(Medicamento m)
        {
            string consulta = "INSERT INTO Medicamento (Nombre, Precio, Stock, Fecha_Vencimiento) " +
                              "VALUES (@Nombre, @Precio, @Stock, @Fecha_Vencimiento)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                conexion.crearParametro("@Nombre", m.Nombre),
                conexion.crearParametro("@Precio", m.Precio),
                conexion.crearParametro("@Stock", m.Stock),
                conexion.crearParametro("@Fecha_Vencimiento", m.Fecha_Vencimiento)
            };

            int filasAfectadas = conexion.EscribirPorComando(consulta, parametros);

            if (filasAfectadas <= 0)
            {
                throw new Exception("¡Ups! No se pudo agregar el medicamento, cariño.");
            }
        }

        public void Eliminar(int id)
        {
            string consulta = "DELETE FROM Medicamento WHERE Id_Medicamento = @Id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                conexion.crearParametro("@Id", id)
            };

            int filasAfectadas = conexion.EscribirPorComando(consulta, parametros);

            if (filasAfectadas <= 0)
            {
                throw new Exception("No se pudo eliminar el medicamento, hermosa. Quizás no existe o hubo un error.");
            }
        }

        public Medicamento BuscarPorNombre(string nombre)
        {
            string consulta = "SELECT * FROM Medicamento WHERE Nombre = @Nombre";

            SqlParameter[] parametros = new SqlParameter[]
            {
                conexion.crearParametro("@Nombre", nombre)
            };

            DataTable tabla = conexion.LeerPorComando(consulta, parametros);

            if (tabla.Rows.Count == 0)
            {
                return null; 
            }

            DataRow fila = tabla.Rows[0];

            Medicamento m = new Medicamento
            {
                Id_Medicamento = Convert.ToInt32(fila["Id_Medicamento"]),
                Nombre = fila["Nombre"].ToString(),
                Precio = Convert.ToInt32(fila["Precio"]),
                Stock = Convert.ToInt32(fila["Stock"]),
                Fecha_Vencimiento = fila["Fecha_Vencimiento"] != DBNull.Value
                    ? Convert.ToDateTime(fila["Fecha_Vencimiento"])
                    : DateTime.MinValue
            };

            return m;
        }


        public void Actualizar(Medicamento m)
        {
            string consulta = $"UPDATE Medicamento SET " +
                              $"Nombre = '{m.Nombre}', " +
                              $"Precio = {m.Precio}, " +
                              $"Stock = {m.Stock}, " +
                              $"Fecha_Vencimiento = '{m.Fecha_Vencimiento:yyyy-MM-dd}' " +
                              $"WHERE Id_Medicamento = {m.Id_Medicamento}";

            conexion.EscribirPorComando(consulta);
        }





    }
}
