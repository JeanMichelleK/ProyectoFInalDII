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
        private bool _activo;

        [DisplayName("Codigo de la Ciudad")]
        public string CodigoCiudad
        {
            get
            {
                return _codigoCiudad;
            }

            set
            {
                if (value.Trim().Length != 6 && !value.All(char.IsLetter))
                { throw new Exception("El codigo debe ser estrictamente de 6 letras"); }
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
                if (value.Trim().Length <= 3)
                { throw new Exception("El nombre debe tener al menos 3 letras"); }
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
                if (value.Trim().Length <= 4)
                { throw new Exception("Debe ingresar un pais valido"); }
                _pais = value;
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
                if (value == false)
                    throw new Exception("El aeropuerto no esta activo");
                _activo = value;
            }
        }

        public Ciudad(string _codigoCiudad, string _nombre, string _pais, bool activo)
        {
            this._codigoCiudad = _codigoCiudad;
            this._nombre = _nombre;
            this._pais = _pais;
            this._activo = activo;
        }
    }
}