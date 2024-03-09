using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Pasaje
    {
        private string _NroPasaporte;
        private Cliente _Cliente;
        private int _asiento;

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        public int Asiento
        {
            get { return _asiento; }
            set { _asiento = value; }
        }

        public string NroPasaporte
        {
            get { return _NroPasaporte; }
            set { _NroPasaporte = value; }
        }

        public Pasaje()
        {

        }

        public Pasaje(Cliente _Cliente, int _asiento)
        {
            Cliente = _Cliente;
            Asiento = _asiento;
        }
        public void Validar()
        {
            if (this.Cliente == null)
                throw new Exception("Se debe saber a quien le pertenece el pasaje.");
            if (!(this.Asiento > 0 && Asiento <= 300))
                throw new Exception("El asiento debe estar entre los rangos 1 y 300");

        }
    }
}