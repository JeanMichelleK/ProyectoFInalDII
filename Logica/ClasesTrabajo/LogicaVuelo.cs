﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaVuelo : ILogicaVuelo
    {
        private static LogicaVuelo _Instancia = null;
        private LogicaVuelo() { }
        public static LogicaVuelo GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaVuelo();
            return _Instancia;
        }
        public void Alta(Vuelo unV)
        {
            FabricaPersistencia.GetPersistenciaVuelo().Alta(unV);
        }
        public List<Vuelo> ListadoVuelos()
        {
            return (FabricaPersistencia.GetPersistenciaVuelo().ListadoVuelos());
        }
    }
}