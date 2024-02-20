using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EC
{
    public class Venta
    {
        private int _idVenta;
        private Cliente _Cliente;
        private string _NroPasaporte;
        private Vuelo _Vuelo;
        private string _CodigoV;
        private DateTime _fechaVenta;
        private double _monto;
        private Empleado _usuario;
        private string _Usu;
        private List<Pasaje> _ListaP;

        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }
        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        public Vuelo Vuelo
        {
            get { return _Vuelo; }
            set { _Vuelo = value; }
        }
        public DateTime FechaVenta
        {
            get { return _fechaVenta; }
            set { _fechaVenta = value; }
        }

        public double Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public Empleado Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public List<Pasaje> ListaP
        {
            get { return _ListaP; }
            set { _ListaP = value; }
        }

        public string NroPasaporte
        {
            get { return _NroPasaporte; }
            set { _NroPasaporte = value; }
        }

        public string Usu
        {
            get { return _Usu; }
            set { _Usu = value; }
        }

        public string CodigoV
        {
            get { return _CodigoV; }
            set { _CodigoV = value; }
        }

        public Venta() { }
        public Venta(int _idVenta, Cliente _Cliente, Vuelo _Vuelo, DateTime _fechaVenta, double _monto, Empleado _usuario, List<Pasaje> _ListaP)
        {
            IdVenta = _idVenta;
            Cliente = _Cliente;
            Vuelo = _Vuelo;
            FechaVenta = _fechaVenta;
            Monto = _monto;
            Usuario = _usuario;
            ListaP = _ListaP;
        }
        public void Validar()
        {
            if (this.Cliente == null)
                throw new Exception("Se debe saber el cliente que paga.");
            if (this.Vuelo == null)
                throw new Exception("Se debe saber a que vuelo pertenece.");
            if (this.Monto <= 0)
                 throw new Exception("El monto debe ser mayor a 0.");
            if (this.Usuario == null)
                throw new Exception("Se debe saber el empleado que genera la compra.");
            if (this.ListaP == null)
                throw new Exception("Se necesita la lista de pasajes vendidos.");
        }
    }
}