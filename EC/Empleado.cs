﻿using System;
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
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
        public string Contraseña
        {
            get
            {
                return _contraseña;
            }

            set
            {
                _contraseña = value;
            }
        }
        public string NomCompleto
        {
            get
            {
                return _nomCompleto;
            }

            set
            {
                _nomCompleto = value;
            }
        }
        public string Labor
        {
            get
            {
                return _labor;
            }

            set
            {
                string[] rolesPermitidos = { "Gerente", "Vendedor", "Admin" };

                if (value == null || !rolesPermitidos.Contains(value))
                {
                    throw new Exception("El valor de Labor debe ser 'Gerente', 'Vendedor' o 'Admin'.");
                }
                _labor = value;
            }
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
    }
}