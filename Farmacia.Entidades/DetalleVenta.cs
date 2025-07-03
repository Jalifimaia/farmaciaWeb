using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class DetalleVenta
    {
        private int _id_detalle;
        private int _id_venta;
        private int _id_medicamento;
        private int _cantidad;
        private float _subTotal;
        private int _precio_unitario;

        public int Id_Detalle
        {
            get { return _id_detalle; }
            set { _id_detalle = value; }
        }

        public int Id_Venta
        {
            get { return _id_venta; }
            set { _id_venta = value; }
        }

        public int Id_Medicamento
        {
            get { return _id_medicamento; }
            set { _id_medicamento = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        

        public float SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }

        public int Precio_Unitario
        {
            get { return _precio_unitario; }
            set { _precio_unitario = value; }
        }

        // Propiedades de navegación
        private Venta _venta;
        private Medicamento _medicamento;

        public Venta Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }

        public Medicamento Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }
    }
}