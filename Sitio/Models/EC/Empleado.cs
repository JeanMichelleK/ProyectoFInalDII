﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sitio.Models.EC
{
    public class Empleado
    {
        string _usuario;
        string _contraseña;
        string _nomCompleto;
        string _labor;

        [Required(ErrorMessage = "Ingrese el usuario")]
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
        [Required(ErrorMessage = "Ingrese la contraseña")]
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
        [Required(ErrorMessage = "Ingrese nombre completo")]
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
        [Required(ErrorMessage = "Ingrese labor")]
        public string Labor
        {
            get
            {
                return _labor;
            }

            set
            {
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