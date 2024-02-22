using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaCiudad GetLogicaCiudad()
        {
            return (LogicaCiudad.GetInstancia());
        }
        public static ILogicaAeropuerto GetLogicaAeropuerto()
        {
            return (LogicaAeropuerto.GetInstancia());
        }
        public static ILogicaVuelo GetLogicaVuelo()
        {
            return (LogicaVuelo.GetInstancia());
        }
        public static ILogicaEmpleado GetLogicaEmpleado()
        {
            return (LogicaEmpleado.GetInstancia());
        }
        public static ILogicaCliente GetLogicaCliente()
        {
            return (LogicaCliente.GetInstancia());
        }
        public static ILogicaVenta GetLogicaVenta()
        {
            return (LogicaVenta.GetInstancia());
        }
    }
}
