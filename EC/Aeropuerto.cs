using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Aeropuerto
    {
        private string _codigoA;
        private string _nombre;
        private string _direccion;
        private double _impuestoSalida;
        private double _impuestoLlegada;
        private Ciudad _ciudad;
        private bool _activo;

        [DisplayName("Codigo de Aeropuerto")]
        public string CodigoA
        {
            get
            {
                return _codigoA;
            }

            set
            {
                if (value.Trim().Length != 3 && !value.All(char.IsLetter))
                { 
                    throw new Exception("El codigo debe ser estrictamente de 3 letras");
                }
                _codigoA = value;
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


        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                if (value.Trim().Length <= 5)
                { throw new Exception("Debe ingresar una direccion valida"); }
                _direccion = value;
            }
        }

        public double ImpuestoSalida
        {
            get
            {
                return _impuestoSalida;
            }

            set
            {
                if (value <= 0)
                { throw new Exception("El impuesto debe ser mayor a 0"); }
                _impuestoSalida = value;
            }
        }

        public double ImpuestoLlegada
        {
            get
            {
                return _impuestoLlegada;
            }

            set
            {
                if (value <= 0)
                { throw new Exception("El impuesto debe ser mayor a 0"); }
                _impuestoLlegada = value;
            }
        }

        public Ciudad Ciudad
        {
            get
            {
                return _ciudad;
            }

            set
            {
                if (value == null)
                { throw new Exception("Se debe saber la ciudad"); }
                _ciudad = value;
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
                { throw new Exception("El aeropuerto no esta activo"); }
                _activo = value;
            }
        }

        public Aeropuerto()
        {

        }
        public Aeropuerto(string _codigoA, string _nombre, string _direccion, double _impuestoSalida, double _impuestoLlegada, Ciudad _ciudad, bool _activo)
        {
            this._codigoA = _codigoA;
            this._nombre = _nombre;
            this._direccion = _direccion;
            this._impuestoSalida = _impuestoSalida;
            this._impuestoLlegada = _impuestoLlegada;
            this._ciudad = _ciudad;
            this._activo = _activo;
        }
    }
}