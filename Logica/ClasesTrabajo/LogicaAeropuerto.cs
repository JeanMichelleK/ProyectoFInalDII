using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;


namespace Logica
{
    internal class LogicaAeropuerto : ILogicaAeropuerto
    {
        private static LogicaAeropuerto _Instancia = null;
        private LogicaAeropuerto() { }
        public static LogicaAeropuerto GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaAeropuerto();
            return _Instancia;
        }
        public void Alta(Aeropuerto unA)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Alta(unA);
        }
        public void Modificar(Aeropuerto unA)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Modificar(unA);
        }
        public void Baja(Aeropuerto unA)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Baja(unA);
        }
        public Aeropuerto Buscar(string pCodigo)
        {
            return (FabricaPersistencia.GetPersistenciaAeropuerto().BuscarAeropuertoActivo(pCodigo));
        }
    }
}
