using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
     class Vendedor
    {
		private int _id_vendedor;

		public int Id_Vendedor
		{
			get { return _id_vendedor; }
			set { _id_vendedor = value; }
		}



        public void AplicarDescuentoSegunPerfil()
        {
            throw new NotImplementedException();
        }

        public void BuscarClientePorId(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void BuscarVentaPorId(int idVenta)
        {
            throw new NotImplementedException();
        }

        public void EliminarVenta(int idVenta)
        {
            throw new NotImplementedException();
        }

        public void ListarVentas()
        {
            throw new NotImplementedException();
        }

        public void ModificarVenta(int idVenta)
        {
            throw new NotImplementedException();
        }

        public void RegistrarCliente(string nombre, string tipoPerfil)
        {
            throw new NotImplementedException();
        }

        public void RegistrarVenta(int idCliente, int idMedicamento, int cantidad)
        {
            throw new NotImplementedException();
        }

    }
}
