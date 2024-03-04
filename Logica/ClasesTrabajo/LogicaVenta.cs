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
        public void Alta(Venta unaV, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaVenta().Alta(unaV, pUsu);
        }
        public List<Venta> VentaVuelo(Vuelo unV, Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaVenta().VentaVuelo(unV, pUsu));
        }
    }
}
