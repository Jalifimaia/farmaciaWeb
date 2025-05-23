using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Gerente
    {
		private int _id_gerente;

		public int Id_Gerente
		{
			get { return _id_gerente; }
			set { _id_gerente = value; }
		}



        public bool GenerarAlertaStock(int stock)
        {
            throw new NotImplementedException();
        }

        public void GenerarReporteMedicamentoMasVendido()
        {
            throw new NotImplementedException();
        }

        public void GenerarReporteStockGeneral()
        {
            throw new NotImplementedException();
        }

        public void GenerarReporteVentas()
        {
            throw new NotImplementedException();
        }

        public void GenerarReporteVentasGeolocalizacion()
        {
            throw new NotImplementedException();
        }

    }
}
