using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class Usuario
    {
		private int _id_usuario;
        private string _nombre;
        private string _correo_Electronico;
        private string _contraseña;
		private int _id_Rol;
        private Rol _Rol;
        public int Id_Usuario
		{
			get { return _id_usuario; }
			set { _id_usuario = value; }
		}

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string Correo_Electronico
		{
			get { return _correo_Electronico; }
			set { _correo_Electronico = value; }
		}

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contraseña
		{
			get { return _contraseña; }
			set { _contraseña = value; }
		}


		public int id_Rol
		{
			get { return _id_Rol; }
			set { _id_Rol = value; }
		}

        [Range(1, 4, ErrorMessage = "Debe seleccionar un rol")]
        public Rol Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
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
