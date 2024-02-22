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
        public void Alta(Cliente unC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCliente().Alta(unC, pUsu);
        }
        public void Modificar(Cliente unC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCliente().Modificar(unC, pUsu);
        }
        public void Baja(Cliente unC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCliente().Baja(unC, pUsu);
        }
        public Cliente Buscar(string pNroPasaporte, Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaCliente().BuscarClienteActivo(pNroPasaporte, pUsu));
        }
        public List<Cliente> ListadoClientes(Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaCliente().ListadoClientes(pUsu));
        }
    }
}
