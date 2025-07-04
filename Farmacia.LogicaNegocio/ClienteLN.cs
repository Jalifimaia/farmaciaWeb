using System;
using System.Collections.Generic;
using Farmacia.Datos;
using Farmacia.Entidades;

namespace Farmacia.LogicaNegocio
{
    public class ClienteLN
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public bool RegistrarCliente(Cliente cliente)
        {
            try
            {
                return clienteDAL.RegistrarCliente(cliente); // acceso es ClienteDAL
            }
            catch
            {
                return false;
            }
        } 


  
        public List<Cliente> ObtenerTodos()
        {
            // Lógica para obtener todos los clientes, ej:
            return new ClienteDAL().ObtenerTodos(); // o como tengas la capa de acceso a datos
        }





      

        public List<Cliente> BuscarClientes(string criterio)
        {
            return clienteDAL.BuscarClientes(criterio);
        }


        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerTodos();
        }

        // Validación sencilla de email (podés mejorarla)
        private bool IsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
