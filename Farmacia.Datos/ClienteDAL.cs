using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Farmacia.Entidades;
using DAL;

namespace Farmacia.Datos
{
    public class ClienteDAL
    {
        private Conexion conexion = new Conexion();

        public void Insertar(Cliente cliente)
        {
            string query = @"INSERT INTO Cliente (Nombre, Apellido, Email, DNI, TipoCliente)
                             VALUES (@Nombre, @Apellido, @Email, @DNI, @TipoCliente)";

            SqlParameter[] parametros =
            {
                conexion.crearParametro("@Nombre", cliente.Nombre),
                conexion.crearParametro("@Apellido", cliente.Apellido),
                conexion.crearParametro("@Email", cliente.Email),
                conexion.crearParametro("@DNI", cliente.DNI),
                conexion.crearParametro("@TipoCliente", cliente.TipoCliente)
            };

            conexion.EscribirPorComando(query, parametros);
        }

        public List<Cliente> ObtenerTodos()
        {
            string consulta = "SELECT * FROM Cliente";
            DataTable tabla = conexion.LeerPorComando(consulta);

            List<Cliente> lista = new List<Cliente>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new Cliente
                {
                    IdCliente = Convert.ToInt32(fila["IdCliente"]),      // coincidir con el nombre en la tabla
                    Nombre = fila["Nombre"].ToString(),
                    Apellido = fila["Apellido"].ToString(),
                    Email = fila["Email"].ToString(),
                    DNI = fila["DNI"].ToString(),
                    TipoCliente = fila["TipoCliente"].ToString()        // coincide con el nombre de la columna en la tabla
                });
            }

            return lista;
        }
    }
}
