using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Entidades;
using Farmacia.DAL;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DAL;
using System.Data;

namespace Farmacia.LogicaNegocio
{
    public class UsuarioLN
    {
        private UsuarioDAL acceso = new UsuarioDAL();
        private UsuarioDAL datos = new UsuarioDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();


        public List<Usuario> ObtenerTodos()
        {
            return usuarioDAL.ObtenerTodos();
        }

        public string CrearUsuario(Usuario usuario)
        {
            try
            {
                usuarioDAL.CrearUsuario(usuario);

                return "Usuario creado correctamente.";
            }
            catch
            {
                return "Error al crear el usuario.";
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            return usuarioDAL.ObtenerPorId(id);
        }

        public string ActualizarUsuario(Usuario usuario)
        {
            try
            {
                usuarioDAL.Actualizar(usuario);
                return "Usuario actualizado correctamente.";
            }
            catch
            {
                return "Error al actualizar el usuario.";
            }
        }

        public string EliminarUsuario(int id)
        {
            try
            {
                usuarioDAL.Eliminar(id);
                return "Usuario eliminado correctamente.";
            }
            catch
            {
                return "Error al eliminar el usuario.";
            }
        }

        public List<Usuario> BuscarUsuarios(string criterio)
        {
            return usuarioDAL.Buscar(criterio);
        }




        public Usuario IniciarSesion(string correo, string contrasenia)
        {
            if (correo == "admin@correo.com" && contrasenia == "1234")
            {
                return new Usuario
                {
                    Id_Usuario = 1,
                    Nombre = "Admin Falsa",
                    Correo_Electronico = correo,
                    Rol = new Rol
                    {
                        Id_Rol = 1,
                        Nombre = "Administrador"
                    }
                };
            }

            if (correo == "farmaceutico@correo.com" && contrasenia == "2222")
            {
                return new Usuario
                {
                    Id_Usuario = 2,
                    Nombre = "Farmacéutico Falso",
                    Correo_Electronico = correo,
                    Rol = new Rol
                    {
                        Id_Rol = 2,
                        Nombre = "Farmaceutico"
                    }
                };
            }


            return acceso.ObtenerUsuario(correo, contrasenia);
        }
       





    }
}
