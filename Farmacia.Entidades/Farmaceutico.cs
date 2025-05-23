using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Farmaceutico : Usuario
    {
		private int _id_farmaceutico;

		public int Id_Farmaceutico
		{
			get { return _id_farmaceutico; }
			set { _id_farmaceutico = value; }
		}

        public void ActualizarMedicamento(string nombre, int stock, int precio)
        {
            
            throw new NotImplementedException();
        }

        public void BuscarMedicamentoPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void EliminarMedicamento(int idMedicamento)
        {
            throw new NotImplementedException();
        }

        public void ListarMedicamentos()
        {
            throw new NotImplementedException();
        }

        public void RegistrarMedicamento(string nombre, char stock, int precio)
        {
            throw new NotImplementedException();
        }



    }
}
