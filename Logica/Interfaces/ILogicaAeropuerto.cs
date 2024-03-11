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
        void Alta(EC.Aeropuerto unA, Empleado pUsu);
        void Modificar(EC.Aeropuerto unA, Empleado pUsu);
        void Baja(EC.Aeropuerto unA, Empleado pUsu);
        Aeropuerto Buscar(string pCodigoA, Empleado pUsu);
        List<Aeropuerto> ListadoAeropuertos(Empleado pUsu);
    }
}
