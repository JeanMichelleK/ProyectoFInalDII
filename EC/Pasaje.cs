using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Pasaje
    {
        private Cliente _Cliente;
        private Venta _Venta;
        private int _asiento;

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
        public Venta Venta
        {
            get
            {
                return _Venta;
            }

            set
            {
                _Venta = value;
            }
        }

        public int Asiento
        {
            get
            {
                return _asiento;
            }

            set
            {
                if (!(value > 0 && Asiento <= 300))
                { throw new Exception("El asiento debe estar entre los rangos 1 y 300"); }
                _asiento = value;
            }
        }


        public Pasaje()
        {

        }


        public Pasaje(Cliente _nroPasaporte, Venta _idVenta, int _asiento)
        {
            this._Cliente = _nroPasaporte;
            this._Venta = _idVenta;
            this._asiento = _asiento;
        }
    }
}