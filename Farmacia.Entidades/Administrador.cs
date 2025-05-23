using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     public class Administrador
    {

		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}




        public Usuario BuscarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void CrearUsuario(string nombre, char rol, string correo, string contrasenia)
        {
            throw new NotImplementedException();
        }

        public void EliminarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public void ModificarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
