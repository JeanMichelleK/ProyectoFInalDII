using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC
{
    public class Cliente
    {

        private string _nroPasaporte;
        private string _nombre;
        private string _passCli;
        private string _NroTarjeta;
        private bool _activo;

        public string NroPasaporte
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

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string PassCli
        {
            get
            {
                return _passCli;
            }

            set
            {
                _passCli = value;
            }
        }

        public string NroTarjeta
        {
            get
            {
                return _NroTarjeta;
            }

            set
            {
                _NroTarjeta = value;
            }
        }

        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                _activo = value;
            }
        }

        public Cliente()
        {

        }
        public Cliente(string _nroPasaporte, string _nombre, string _passCli, string _NroTarjeta, bool _activo)
        {
            this.NroPasaporte = _nroPasaporte;
            this.Nombre = _nombre;
            this.PassCli = _passCli;
            this.NroTarjeta = _NroTarjeta;
            this.Activo = _activo;
        }
    }
}