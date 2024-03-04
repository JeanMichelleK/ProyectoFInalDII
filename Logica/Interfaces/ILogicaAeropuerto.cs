using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaAeropuerto
    {
        void Alta(Aeropuerto unA, Empleado pUsu);
        void Modificar(Aeropuerto unA, Empleado pUsu);
        void Baja(Aeropuerto unA, Empleado pUsu);
        Aeropuerto Buscar(string pCodigoA, Empleado pUsu);
        List<Aeropuerto> ListadoAeropuertos(Empleado pUsu);
    }
}
