using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Datos;
using Farmacia.Entidades;

namespace Farmacia.LogicaNegocio
{
    public class RolLn
    {
        private RolDAL rolDAL = new RolDAL();

        public List<Rol> ObtenerRoles()
        {
            return rolDAL.ObtenerRoles();
        }
    }
}
