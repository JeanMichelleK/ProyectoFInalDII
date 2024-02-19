using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaAeropuerto
    {
        void Alta(Aeropuerto unA);
        void Modificar(Aeropuerto unA);
        void Baja(Aeropuerto unA);
        Aeropuerto BuscarAeropuertoActivo(string pCodigo);
    }
}
