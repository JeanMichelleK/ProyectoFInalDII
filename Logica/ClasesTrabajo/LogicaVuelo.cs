using System;
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
            if (unV.FechaHoraSalida >= DateTime.Now)
            {
                FabricaPersistencia.GetPersistenciaVuelo().Alta(unV);
            }
            else
            {
                throw new Exception("El vuelo no puede ser en el pasado.");
            }
        }
        public List<Vuelo> ListadoVuelos()
        {
            return (FabricaPersistencia.GetPersistenciaVuelo().ListadoVuelos());
        }
    }
}
