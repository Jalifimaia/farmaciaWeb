using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class Rol
    {
		private int _id_Rol;

		public int id_Rol
		{
			get { return _id_Rol; }
			set { _id_Rol = value; }
		}

		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
        public ICollection<Usuario> Usuarios { get; set; }


    }
}
