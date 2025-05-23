using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Cliente
    {
		private int _id_cliente;

		public int Id_Cliente
		{
			get { return _id_cliente; }
			set { _id_cliente = value; }
		}

		private string _tipo_Cliente;

		public string Tipo_Cliente
		{
			get { return _tipo_Cliente; }
			set { _tipo_Cliente = value; }
		}


	}
}
