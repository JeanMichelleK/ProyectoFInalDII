using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

namespace EC
{
    public class Vuelo
    {
        private string _codigoVuelo;
        private DateTime _fechaHoraSalida;
        private DateTime _fechaHoraLlegada;
        private Aeropuerto _aeropuertoLlegada;
        private Aeropuerto _aeropuertoPartida;
        private string _CodigoAS;
        private string _CodigoAL;
        private double _precio;
        private int _cantidadAsientos;

        [DisplayName("Codigo del vuelo")]
        public string CodigoVuelo
        {
            get { return _codigoVuelo; }
            set { _codigoVuelo = value; }
        }

        [DisplayName("Fecha y hora de salida")]
        public DateTime FechaHoraSalida
        {
            get { return _fechaHoraSalida; }
            set {
                if (value <= DateTime.Now)
                { throw new Exception("La fecha y hora de salida debe ser en el futuro"); } //Esto va en la logica
                _fechaHoraSalida = value;
            }
        }
        [DisplayName("Fecha y hora de llegada")]
        public DateTime FechaHoraLlegada
        {
            get { return _fechaHoraLlegada; }
            set { _fechaHoraLlegada = value; }
        }
        [DisplayName("Aeropuerto destino")]
        public Aeropuerto AeropuertoLlegada
        {
            get { return _aeropuertoLlegada; }
            set { _aeropuertoLlegada = value; }
        }
        [DisplayName("Aeropuerto partida")]
        public Aeropuerto AeropuertoPartida
        {
            get { return _aeropuertoPartida; }
            set { _aeropuertoPartida = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        [DisplayName("Cantidad de asientos")]
        public int CantidadAsientos
        {
            get { return _cantidadAsientos; }
            set { _cantidadAsientos = value; }
        }

        public string CodigoAS
        {
            get { return _CodigoAS; }
            set { _CodigoAS = value; }
        }

        public string CodigoAL
        {
            get { return _CodigoAL; }
            set { _CodigoAL = value; }
        }

        public Vuelo()
        {

        }
        public Vuelo(string _codigoVuelo, DateTime _fechaHoraSalida, DateTime _fechaHoraLlegada, Aeropuerto _aeropuertoLlegada, Aeropuerto _aeropuertoPartida, double _precio, int _cantidadAsientos)
        {
            this.CodigoVuelo = _codigoVuelo;
            this.FechaHoraSalida = _fechaHoraSalida;
            this.FechaHoraLlegada = _fechaHoraLlegada;
            this.AeropuertoLlegada = _aeropuertoLlegada;
            this.AeropuertoPartida = _aeropuertoPartida;
            this.Precio = _precio;
            this.CantidadAsientos = _cantidadAsientos;
        }
        public void Validar()
        {
            string Patron = @"^\d{12}[a-zA-Z]{3}$";
            if (!(Regex.IsMatch(this.CodigoVuelo, Patron)))
                throw new Exception("El codigo del vuelo tiene este formato 'yyyyMMddHHmmAer'");
            if (this.FechaHoraLlegada < FechaHoraSalida)
             throw new Exception("El vuelo debe llegar en una fecha futura, los viajes al pasado todavia no existen");
            if (this.AeropuertoLlegada == null)
             throw new Exception("El aeropuerto no se encuentra disponible");
            if (this.AeropuertoPartida == null)
             throw new Exception("El aeropuerto no se encuentra disponible");
            if (this.Precio <= 0)
                throw new Exception("El precio no puede ser negativo");
            if (!(this.CantidadAsientos>= 100 && this.CantidadAsientos <= 300))
             throw new Exception("La cantidad de asientos debe estar entre los rangos 100 y 300"); 
        }
    }

}