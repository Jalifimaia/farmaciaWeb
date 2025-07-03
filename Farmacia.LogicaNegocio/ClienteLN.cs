using System;
using System.Collections.Generic;
using Farmacia.Datos;
using Farmacia.Entidades;

namespace Farmacia.LogicaNegocio
{
    public class ClienteLN
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public void RegistrarCliente(Cliente cliente)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new ArgumentException("El email es obligatorio.");

            if (!IsEmailValido(cliente.Email))
                throw new ArgumentException("El email no es válido.");

            if (string.IsNullOrWhiteSpace(cliente.DNI))
                throw new ArgumentException("El DNI es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.TipoCliente))
                throw new ArgumentException("Debe seleccionar un tipo de cliente.");

            // Podés agregar validación para que no haya DNI duplicados, por ejemplo:
            // if (clienteDAL.ExisteDNI(cliente.DNI))
            //    throw new ArgumentException("El DNI ya está registrado.");

            // Guardar cliente
            clienteDAL.Insertar(cliente);
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
