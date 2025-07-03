using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class Cliente
    {
        //id del cliente
        private int _id_Cliente;

        public int Id_Cliente
        {
            get { return _id_Cliente; }
            set { _id_Cliente = value; }
        }

        
        //nombre del cliente
        [Required(ErrorMessage = "El nombre es obligatorio")]
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        //apellido del cliente
        [Required(ErrorMessage = "El apellido es obligatorio")]
        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        //correo electronico del cliente
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        private string _correo_electronico;

        public string Correo_Electronico
        {
            get { return _correo_electronico; }
            set { _correo_electronico = value; }
        }

        
        //DNI del cliente
        [Required(ErrorMessage = "El DNI es obligatorio")]
        private string _dni;

        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }



        //que tipo de perfil tiene un cliente
        [Required(ErrorMessage = "Debe seleccionar un tipo de perfil")]
        private string _tipo_cliente;

        public string Tipo_Cliente
        {
            get { return _tipo_cliente; }
            set { _tipo_cliente = value; }
        }

        
    }
}
