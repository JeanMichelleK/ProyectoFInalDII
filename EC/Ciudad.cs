using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Ciudad
    {
        private string _codigoCiudad;
        private string _nombre;
        private string _pais;
        private bool activo;

        [DisplayName("Codigo de la Ciudad")]
        public string CodigoCiudad
        {
            get
            {
                return _codigoCiudad;
            }

            set
            {
                _codigoCiudad = value;
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

        public string Pais
        {
            get
            {
                return _pais;
            }

            set
            {
                _pais = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public Ciudad(string _codigoCiudad, string _nombre, string _pais, bool activo)
        {
            this._codigoCiudad = _codigoCiudad;
            this._nombre = _nombre;
            this._pais = _pais;
            this.activo = activo;
        }

        public void Validar()
        {
            if (this.CodigoCiudad.Trim().Length != 6 && !this.CodigoCiudad.All(char.IsLetter))
                throw new Exception("El codigo debe ser estrictamente de 6 letras");
            if (this.Nombre.Trim().Length <= 3)
                throw new Exception("El nombre debe tener al menos 3 letras");
            if (this.Pais.Trim().Length <= 5)
                throw new Exception("Debe ingresar un pais valido");
            if (this.Activo == false)
                throw new Exception("El aeropuerto no esta activo");
        }
    }
}