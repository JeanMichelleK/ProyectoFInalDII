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
        public void Alta(Ciudad unaC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Alta(unaC, pUsu);
        }
        public void Modificar(Ciudad unaC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Modificar(unaC, pUsu);
        }
        public void Baja(Ciudad unaC, Empleado pUsu)
        {
            FabricaPersistencia.GetPersistenciaCiudad().Baja(unaC, pUsu);
        }
        public Ciudad Buscar(string pCodigo, Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaCiudad().BuscarCiudadActiva(pCodigo,pUsu));
        }
        public List<Ciudad> ListadoCiudades(Empleado pUsu)
        {
            return (FabricaPersistencia.GetPersistenciaCiudad().ListadoCiudades(pUsu));
        }
    }
}
