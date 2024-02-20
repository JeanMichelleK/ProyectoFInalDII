using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace EC
{
    public class Cliente
    {

        private string _nroPasaporte;
        private string _nombre;
        private string _passCli;
        private string _NroTarjeta;

        public string NroPasaporte
        {
            get { return _nroPasaporte; }
            set { _nroPasaporte = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string PassCli
        {
            get { return _passCli; }
            set { _passCli = value; }
        }

        public string NroTarjeta
        {
            get { return _NroTarjeta; }
            set { _NroTarjeta = value; }
        }

        public Cliente()
        {

        }
        public Cliente(string _nroPasaporte, string _nombre, string _passCli, string _NroTarjeta)
        {
            this.NroPasaporte = _nroPasaporte;
            this.Nombre = _nombre;
            this.PassCli = _passCli;
            this.NroTarjeta = _NroTarjeta;
        }
        public void Validar()
        {
            if (this.NroPasaporte.Trim().Length != 9)
                throw new Exception("El numero de pasaporte debe de ser de 9 de largo.");
            if (this.Nombre.Trim().Length < 3 || this.Nombre.Trim().Length > 30)
                throw new Exception("El nombre solo puede tener entre 3 y 30 caracteres.");
            if (this.PassCli.Trim().Length < 5 || this.PassCli.Trim().Length > 16)
                throw new Exception("La contraseña tiene que tener de 5 a 16 caracteres.");
            string Patron = @"^\d{16}$";
            if (!(Regex.IsMatch(this.NroTarjeta, Patron)))
                throw new Exception("El numero de la tarjeta son 16 numeros.");
        }
    }
}