using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaPasaje
    {
        void Alta(Pasaje unP);
        List<Pasaje> ListarPasajes(int pCodigoV);
    }
}
