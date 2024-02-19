using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaPasaje : ILogicaPasaje
    {
        private static LogicaPasaje _Instancia = null;
        private LogicaPasaje() { }
        public static LogicaPasaje GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaPasaje();
            return _Instancia;
        }
        public void Alta(Pasaje unP)
        {
            FabricaPersistencia.GetPersistenciaPasaje().Alta(unP);
        }
        public List<Pasaje> ListarPasajes(int pCodigoV)
        {
            return (FabricaPersistencia.GetPersistenciaPasaje().ListarPasajes(pCodigoV));
        }
    }
}
