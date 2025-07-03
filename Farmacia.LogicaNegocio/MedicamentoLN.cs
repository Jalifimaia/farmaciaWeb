using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Farmacia.DAL;
using Farmacia.Entidades;
using System.Collections.Generic;

namespace Farmacia.LogicaNegocio
{
    public class MedicamentoLN
    {
        private MedicamentoDAL datos = new MedicamentoDAL();

        public List<Medicamento> ObtenerMedicamentos()
        {
            return datos.ObtenerTodos();
        }

        public void RegistrarMedicamento(Medicamento medicamento)
        {

            datos.Agregar(medicamento);
        }

        public void EliminarMedicamento(int id)
        {
            datos.Eliminar(id);
        }
    }
}
