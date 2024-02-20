using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC
{
    public class Empleado
    {
        string _usuario;
        string _contraseña;
        string _nomCompleto;
        string _labor;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public string NomCompleto
        {
            get { return _nomCompleto; }
            set { _nomCompleto = value; }
        }
        public string Labor
        {
            get { return _labor; }
            set { _labor = value; }
        }

        public Empleado()
        { }

        public Empleado(string _usuario, string _contraseña, string _nomCompleto, string _labor)
        {
            this.Usuario = _usuario;
            this.Contraseña = _contraseña;
            this.NomCompleto = _nomCompleto;
            this.Labor = _labor;
        }
        private void Validar()
        {
            if (this.Usuario.Trim().Length != 10)
                throw new Exception("El nombre de usuario es de 10 caracteres.");
            if (this.Contraseña.Trim().Length < 5 || this.Contraseña.Trim().Length > 16)
                throw new Exception("La contraseña debe ser de 5 a 16 caracteres.");
            if (this.NomCompleto.Trim().Length < 5 || this.NomCompleto.Trim().Length > 30)
                throw new Exception("El nombre tiene que tener mas de 5 caracteres y menos de 30.");
            string[] rolesPermitidos = { "Gerente", "Vendedor", "Admin" };
            if (this.Labor == null || !rolesPermitidos.Contains(this.Labor))            
                throw new Exception("El valor de Labor debe ser 'Gerente', 'Vendedor' o 'Admin'.");
        }
    }
}