using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaVuelo
    {
        void Alta(Vuelo unV);

        List<Vuelo> ListadoVuelos();
    }
}
