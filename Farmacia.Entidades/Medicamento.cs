using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     public class Medicamento
    {

		private int _id_medicamento;
        private string _nombre;
        private int _stock;
        private DateTime _fecha_vencimiento;
        private int _precio;
        public int Id_Medicamento
		{
			get { return _id_medicamento; }
			set { _id_medicamento = value; }
		}
		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		public int Stock
		{
			get { return _stock; }
			set { _stock = value; }
		}

		public DateTime Fecha_Vencimiento
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}


		public int Precio
		{
			get { return _precio; }
			set { _precio = value; }
		}











	}
}
