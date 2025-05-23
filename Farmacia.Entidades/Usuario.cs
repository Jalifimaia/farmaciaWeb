using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class Usuario
    {
		private int _id_usuario;

		public int Id_Usuario
		{
			get { return _id_usuario; }
			set { _id_usuario = value; }
		}
		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		private string _apellido;

		public string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		private string _correo_Electronico;

		public string Correo_Electronico
		{
			get { return _correo_Electronico; }
			set { _correo_Electronico = value; }
		}

		private string _contrasenia;

		public string Contrasenia
		{
			get { return _contrasenia; }
			set { _contrasenia = value; }
		}

		private DateTime _fecha_de_nacimiento;

		public DateTime Fecha_de_nacimiento
		{
			get { return _fecha_de_nacimiento; }
			set { _fecha_de_nacimiento = value; }
		}

		private string _rol;

		public string Rol
		{
			get { return _rol; }
			set { _rol = value; }
		}








        public virtual bool CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public virtual bool IniciarSesion(string correo, string contrasenia)
        {
            throw new NotImplementedException();
        }


    }



}
