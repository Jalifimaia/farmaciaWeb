using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Entidades;

namespace Farmacia.LogicaNegocio
{
    public class UsuarioLN
    {


        public static Usuario IniciarSesion(string correo, string contrasenia)
        {
            if (correo == "admin@gmail.com" && contrasenia == "1111")
            {
                return new Usuario { Nombre = "Administrador", Rol = "Administrador" };
            }
            else if (correo == "Farmaceutico@correo.com" && contrasenia == "2222")
            {
                return new Usuario { Nombre = "Farmaceutico", Rol = "Farmaceutico" };
            }
            else if (correo == "Gerente@correo.com" && contrasenia == "3333")
            {
                return new Usuario { Nombre = "Gerente", Rol = "Gerente" };
            }
            else if (correo == "Vendedor@correo.com" && contrasenia == "4444")
            {
                return new Usuario { Nombre = "Vendedor", Rol = "Vendedor" };
            }

            // Si no coincide ninguno, retorna null
            return null;
        }


    }
}
