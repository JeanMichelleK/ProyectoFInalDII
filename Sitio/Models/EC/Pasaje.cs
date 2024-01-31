using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sitio.Models.EC
{
    public class Pasaje
    {
        private Cliente _nroPasaporte;
        private Venta _idVenta;
        private int _asiento;

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
        [DisplayName("Id de la venta")]
        public Venta IdVenta
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

        public int Asiento
        {
            get
            {
                return _asiento;
            }

            set
            {
                _asiento = value;
            }
        }


        public Pasaje()
        {

        }
   

        public Pasaje(Cliente _nroPasaporte, Venta _idVenta, int _asiento, List<Pasaje> _listaP)
        {
            this._nroPasaporte = _nroPasaporte;
            this._idVenta = _idVenta;
            this._asiento = _asiento;
        }

        public void Validar()
        {
            if (!(this.Asiento > 0 && Asiento <= 300))
                throw new Exception("El asiento debe estar entre los rangos 1 y 300");
        }
    }
}