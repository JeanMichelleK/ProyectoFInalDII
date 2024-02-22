using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using EC;
namespace Logica
{
    internal class LogicaEmpleado : ILogicaEmpleado
    {
        private static LogicaEmpleado _Instancia = null;
        private LogicaEmpleado() { }
        public static LogicaEmpleado GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaEmpleado();
            return _Instancia;
        }
        public Empleado Buscar(string pUsu, Empleado pUsuario)
        {
            return (FabricaPersistencia.GetPersistenciaEmpleado().Buscar(pUsu, pUsuario));
        }
        public Empleado Logueo(string pUsu, string pPass)
        {
            return (FabricaPersistencia.GetPersistenciaEmpleado().Logueo(pUsu, pPass));
        }
    }
}
