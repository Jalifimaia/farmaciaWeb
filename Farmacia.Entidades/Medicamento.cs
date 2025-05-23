using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Medicamento
    {

		private int _id_medicamento;

		public int Id_Medicamento
		{
			get { return _id_medicamento; }
			set { _id_medicamento = value; }
		}

		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private int _stock;

		public int Stock
		{
			get { return _stock; }
			set { _stock = value; }
		}

		private int _stock_minimo;

		public int Stock_minimo
		{
			get { return _stock_minimo; }
			set { _stock_minimo = value; }
		}

		private DateTime _fecha_vencimiento;

		public DateTime Fecha_Vencimiento
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}








	}
}
