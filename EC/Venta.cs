using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Venta
    {
        private int _idVenta;
        private Cliente _Cliente;
        private Vuelo _Vuelo;
        private DateTime _fechaVenta;
        private double _monto;
        private Empleado _usuario;
        private List<Pasaje> _ListaP;

        public int IdVenta
        {
            get
            {
                return _idVenta;
            }

            set
            {
                _idVenta = value;
            }
        }
        public Cliente Cliente
        {
            get
            {
                return _Cliente;
            }

            set
            {
                _Cliente = value;
            }
        }
        public Vuelo Vuelo
        {
            get
            {
                return _Vuelo;
            }

            set
            {
                _Vuelo = value;
            }
        }
        public DateTime FechaVenta
        {
            get
            {
                return _fechaVenta;
            }

            set
            {
                _fechaVenta = value;
            }
        }

        public double Monto
        {
            get
            {
                return _monto;
            }

            set
            {
                if (value < 0)
                { throw new Exception("El monto no puede ser menor a 0"); }
                _monto = value;
            }
        }

        public Empleado Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }

        public List<Pasaje> ListaP
        {
            get
            {
                return _ListaP;
            }

            set
            {
                _ListaP = value;
            }
        }

        public Venta() { }



        public Venta(int _idVenta, Cliente _Cliente, Vuelo _Vuelo, DateTime _fechaVenta, double _monto, Empleado _usuario)
        {
            this.IdVenta = _idVenta;
            this.Cliente = _Cliente;
            this.Vuelo = _Vuelo;
            this.FechaVenta = _fechaVenta;
            this.Monto = _monto;
            this.Usuario = _usuario;
        }
    }
}