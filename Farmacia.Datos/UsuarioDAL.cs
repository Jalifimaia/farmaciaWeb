using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Farmacia.Entidades;
using DAL;



namespace Farmacia.DAL
{
    public class UsuarioDAL
    {
        private Conexion conexion = new Conexion();


        public Usuario ObtenerUsuario(string correo, string contrasenia)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@correo", correo),
        conexion.crearParametro("@contrasenia", contrasenia)
    };

            DataTable tabla = conexion.LeerPorStoreProcedure("sp_Login", parametros);

            if (tabla.Rows.Count > 0)
            {
                var fila = tabla.Rows[0];
                return new Usuario
                {
                    Id_Usuario = Convert.ToInt32(fila["IdUsuario"]),
                    Nombre = fila["Nombre"].ToString(),
                    Correo_Electronico = fila["Correo"].ToString(),
                    Rol = new Rol { Nombre = fila["Rol"].ToString() }
                };
            }

            return null;
        }

        public void CrearUsuario(Usuario usuario)
        {
            string query = "INSERT INTO Usuario (Nombre, Correo_Electronico, Contraseña, Rol) " +
                           "VALUES (@Nombre, @Correo, @Clave, @RolNombre)";

            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Nombre", usuario.Nombre),
        conexion.crearParametro("@Correo", usuario.Correo_Electronico),
        conexion.crearParametro("@Clave", usuario.Contraseña),
        conexion.crearParametro("@RolNombre", usuario.Rol.Nombre)
            };

            int filas = conexion.EscribirPorComando(query, parametros);

            if (filas <= 0)
                throw new Exception("No se pudo insertar el usuario.");
        }



        public void Actualizar(Usuario u)
        {
            string consulta = "UPDATE Usuario SET Nombre = @Nombre, Correo_Electronico = @Correo, Contraseña = @Clave, Rol = @Rol " +
                              "WHERE Id_Usuario = @Id";

            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Nombre", u.Nombre),
        conexion.crearParametro("@Correo", u.Correo_Electronico),
        conexion.crearParametro("@Clave", u.Contraseña),
        conexion.crearParametro("@Rol", u.Rol.Nombre), // <- ahora usamos string
        conexion.crearParametro("@Id", u.Id_Usuario)
            };

            conexion.EscribirPorComando(consulta, parametros);
        }


        public void Eliminar(int id)
        {
            string consulta = "DELETE FROM Usuario WHERE Id_Usuario = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                conexion.crearParametro("@Id", id)
            };

            conexion.EscribirPorComando(consulta, parametros);
        }

        public Usuario ObtenerPorId(int id)
        {
            string consulta = "SELECT * FROM Usuario WHERE Id_Usuario = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Id", id)
            };

            DataTable tabla = conexion.LeerPorComando(consulta, parametros);
            if (tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];

            return new Usuario
            {
                Id_Usuario = Convert.ToInt32(fila["Id_Usuario"]),
                Nombre = fila["Nombre"].ToString(),
                Correo_Electronico = fila["Correo_Electronico"].ToString(),
                Contraseña = fila["Contraseña"].ToString(),
                Rol = new Rol { Nombre = fila["Rol"].ToString() } // <- aquí también
            };
        }


        public List<Usuario> ObtenerTodos()
        {
            string consulta = "SELECT * FROM Usuario";
            DataTable tabla = conexion.LeerPorComando(consulta);

            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow fila in tabla.Rows)
            {
                Usuario u = new Usuario
                {
                    Id_Usuario = Convert.ToInt32(fila["Id_Usuario"]),
                    Nombre = fila["Nombre"].ToString(),
                    Correo_Electronico = fila["Correo_Electronico"].ToString(),
                    Contraseña = fila["Contraseña"].ToString(),
                    Rol = new Rol { Nombre = fila["Rol"].ToString() }  // CORREGIDO
                };

                lista.Add(u);
            }

            return lista;
        }

        public List<Usuario> Buscar(string criterio)
        {
            string consulta = @"
        SELECT * FROM Usuario 
        WHERE Nombre LIKE @Criterio 
           OR Correo_Electronico LIKE @Criterio 
           OR Rol LIKE @Criterio";

            SqlParameter[] parametros = new SqlParameter[]
            {
        conexion.crearParametro("@Criterio", "%" + criterio + "%")
            };

            DataTable tabla = conexion.LeerPorComando(consulta, parametros);
            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow fila in tabla.Rows)
            {
                Usuario u = new Usuario
                {
                    Id_Usuario = Convert.ToInt32(fila["Id_Usuario"]),
                    Nombre = fila["Nombre"].ToString(),
                    Correo_Electronico = fila["Correo_Electronico"].ToString(),
                    Contraseña = fila["Contraseña"].ToString(),
                    Rol = new Rol { Nombre = fila["Rol"].ToString() } // ← Rol como texto
                };
                lista.Add(u);
            }

            return lista;
        }

    }



}







