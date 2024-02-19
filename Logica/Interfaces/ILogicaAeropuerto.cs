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
        void Alta(Aeropuerto unA);
        void Modificar(Aeropuerto unA);
        void Baja(Aeropuerto unA);
        Aeropuerto Buscar(string pCodigoA);
    }
}
