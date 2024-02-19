using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaCiudad : ILogicaCiudad
    {
        private static LogicaCiudad _Instancia = null;
        private LogicaCiudad() { }
        public static LogicaCiudad GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaCiudad();
            return _Instancia;
        }
        public void Alta(Ciudad unaC)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Alta(unaC);
        }
        public void Modificar(Ciudad unaC)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Modificar(unaC);
        }
        public void Baja(Ciudad unaC)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Baja(unaC);
        }
        public Ciudad Buscar(string pCodigo)
        {
            return (FabricaPersistencia.GetPersistenciaCiudad().BuscarCiudadActiva(pCodigo));
        }
    }
}
