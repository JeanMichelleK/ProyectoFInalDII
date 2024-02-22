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
        public void Alta(Aeropuerto unA, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Alta(unA, pUsu);
        }
        public void Modificar(Aeropuerto unA, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Modificar(unA, pUsu);
        }
        public void Baja(Aeropuerto unA, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaAeropuerto().Baja(unA, pUsu);
        }
        public Aeropuerto Buscar(string pCodigo, Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaAeropuerto().BuscarAeropuertoActivo(pCodigo, pUsu));
        }
        public List<Aeropuerto> ListadoAeropuertos(Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaAeropuerto().ListadoAeropuertos(pUsu));
        }
    }
}
