using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Entidades;

namespace Farmacia.Datos
{
    public class RolDAL
    {
        private string cadenaConexion = @"Data Source=TU_SERVIDOR;Initial Catalog=FarmaciaBBDD;Integrated Security=True";

        public List<Rol> ObtenerRoles()
        {
            var roles = new List<Rol>();

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        roles.Add(new Rol
                        {
                            id_Rol = Convert.ToInt32(dr["Id_Rol"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return roles;
        }
    }
}
