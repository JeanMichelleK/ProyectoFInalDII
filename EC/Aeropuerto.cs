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

        [DisplayName("Codigo de Aeropuerto")]
        public string CodigoA
        {
            get
            {
                return _codigoA;
            }

            set
            {
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


        public Aeropuerto()
        {

        }
        public Aeropuerto(string _codigoA, string _nombre, string _direccion, double _impuestoSalida, double _impuestoLlegada, Ciudad _ciudad)
        {
            CodigoA = _codigoA;
            Nombre = _nombre;
            Direccion = _direccion;
            ImpuestoSalida = _impuestoSalida;
            ImpuestoLlegada = _impuestoLlegada;
            Ciudad = _ciudad;
        }

        public void Validar()
        {
            if (this.CodigoA.Trim().Length != 3 && !this.CodigoA.All(char.IsLetter))
                throw new Exception("El codigo debe ser estrictamente de 3 letras");
            if (this.Nombre.Trim().Length <= 3)
             throw new Exception("El nombre debe tener al menos 3 letras");
            if (this.Direccion.Trim().Length <= 5)
             throw new Exception("Debe ingresar una direccion valida");
            if (this.ImpuestoSalida <= 0)
             throw new Exception("El impuesto debe ser mayor a 0");
            if (this.ImpuestoLlegada <= 0)
             throw new Exception("El impuesto debe ser mayor a 0"); 





        }
    }
}