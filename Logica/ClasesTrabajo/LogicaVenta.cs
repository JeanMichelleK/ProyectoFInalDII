using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaVenta : ILogicaVenta
    {
        private static LogicaVenta _Instancia = null;
        private LogicaVenta() { }
        public static LogicaVenta GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaVenta();
            return _Instancia;
        }
        public void Alta(Venta unaV)
        {
            FabricaPersistencia.GetPersistenciaVenta().Alta(unaV);
        }
    }
}
