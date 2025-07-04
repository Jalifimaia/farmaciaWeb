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

        public bool RegistrarCliente(Cliente c)
        {
            Conexion conexion = new Conexion();

            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Nombre", c.Nombre),
        conexion.crearParametro("@Apellido", c.Apellido),
        conexion.crearParametro("@Correo_Electronico", c.Correo_Electronico),
        conexion.crearParametro("@DNI", c.DNI),
        conexion.crearParametro("@Tipo_Cliente", c.Tipo_Cliente)
            };

            try
            {
                int filas = conexion.EscribirPorStoreProcedure("sp_RegistrarCliente", parametros);
                return filas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el cliente: " + ex.Message);
                return false;
            }
        }

        public List<Cliente> BuscarClientes(string criterio)
        {
            List<Cliente> lista = new List<Cliente>();

            SqlParameter[] parametros = new SqlParameter[]
            {
                conexion.crearParametro("@Criterio", criterio)
            };

            DataTable tabla = conexion.LeerPorStoreProcedure("sp_BuscarCliente", parametros);

            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Cliente c = new Cliente
                    {
                        Id_Cliente = Convert.ToInt32(fila["Id_Cliente"]),
                        Nombre = fila["Nombre"].ToString(),
                        Apellido = fila["Apellido"].ToString(),
                        Correo_Electronico = fila["Correo_Electronico"].ToString(),
                        DNI = fila["DNI"].ToString(),
                        Tipo_Cliente = fila["Tipo_Cliente"].ToString()
                    };
                    lista.Add(c);
                }
            }

            return lista;
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
                    Id_Cliente = Convert.ToInt32(fila["Id_Cliente"]),      // coincidir con el nombre en la tabla
                    Nombre = fila["Nombre"].ToString(),
                    Apellido = fila["Apellido"].ToString(),
                    Correo_Electronico = fila["Correo_Electronico"].ToString(),
                    DNI = fila["DNI"].ToString(),
                    Tipo_Cliente = fila["Tipo_Cliente"].ToString()        // coincide con el nombre de la columna en la tabla
                });
            }

            return lista;
        }
    }
}
