using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaCliente : ILogicaCliente
    {
        private static LogicaCliente _Instancia = null;
        private LogicaCliente() { }
        public static LogicaCliente GetInstancia()
        {
            if (_Instancia == null)
                _Instancia = new LogicaCliente();
            return _Instancia;
        }
        public void Alta(Cliente unC)
        {
            FabricaPersistencia.GetPersistenciaCliente().Alta(unC);
        }
        public void Modificar(Cliente unC)
        {
            FabricaPersistencia.GetPersistenciaCliente().Modificar(unC);
        }
        public void Baja(Cliente unC)
        {
            FabricaPersistencia.GetPersistenciaCliente().Baja(unC);
        }
        public Cliente Buscar(string pNroPasaporte)
        {
            return (FabricaPersistencia.GetPersistenciaCliente().BuscarClienteActivo(pNroPasaporte));
        }
    }
}
