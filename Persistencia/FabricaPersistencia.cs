﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaCiudad GetPersistenciaCiudad()
        {
            return (PersistenciaCiudad.GetInstancia());
        }
        public static IPersistenciaAeropuerto GetPersistenciaAeropuerto()
        {
            return (PersistenciaAeropuerto.GetInstancia());
        }
        public static IPersistenciaVuelo GetPersistenciaVuelo()
        {
            return (PersistenciaVuelo.GetInstancia());
        }
        public static IPersistenciaCliente GetPersistenciaCliente()
        {
            return (PersistenciaCliente.GetInstancia());
        }
        public static IPersistenciaVenta GetPersistenciaVenta()
        {
            return (PersistenciaVenta.GetInstancia());
        }
        public static IPersistenciaPasaje GetPersistenciaPasaje()
        {
            return (PersistenciaPasaje.GetInstancia());
        }
        public static IPersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstancia());
        }
    }
}
