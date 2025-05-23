using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Venta
    {
		private int _id_venta;

		public int Id_Venta
		{
			get { return _id_venta; }
			set { _id_venta = value; }
		}

		private int _id_vendedor;

		public int Id_Vendedor
		{
			get { return _id_vendedor; }
			set { _id_vendedor = value; }
		}

		private int _id_cliente;

		public int Id_Cliente
		{
			get { return _id_cliente; }
			set { _id_cliente = value; }
		}

		private int _monto_total;

		public int Monto_Total
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}




	}
}
