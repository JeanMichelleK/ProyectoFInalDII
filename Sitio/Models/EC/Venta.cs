using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sitio.Models.EC
{
    public class Venta
    {
        private int _idVenta;
        private Cliente _nroPasaporte;
        private Vuelo _codigoVuelo;
        private DateTime _fechaVenta;
        private double _monto;
        private Empleado _usuario;

        [DisplayName("Id de la venta")]
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
        [DisplayName("Numero de pasaporte")]
        public Cliente NroPasaporte
        {
            get
            {
                return _nroPasaporte;
            }

            set
            {
                _nroPasaporte = value;
            }
        }
        [DisplayName("Codigo del vuelo")]
        public Vuelo CodigoVuelo
        {
            get
            {
                return _codigoVuelo;
            }

            set
            {
                _codigoVuelo = value;
            }
        }
        [DisplayName("Fecha de la venta")]
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

        public Venta() { }


        
        public Venta(int _idVenta, Cliente _nroPasaporte, Vuelo _codigoVuelo, DateTime _fechaVenta, double _monto, Empleado _usuario)
        {
            this.IdVenta = _idVenta;
            this.NroPasaporte = _nroPasaporte;
            this.CodigoVuelo = _codigoVuelo;
            this.FechaVenta = _fechaVenta;
            this.Monto = _monto;
            this.Usuario = _usuario;
        }

        public void Validar()
        {
            if (this.Monto < 0)
                throw new Exception("El monto no puede ser menor a 0");
        }
    }
}