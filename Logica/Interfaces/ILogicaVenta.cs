using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaVenta
    {
        void Alta(Venta unaV, Empleado pUsu);
        List<Venta> VentaVuelo(Vuelo unV, Empleado pUsu);
    }
}
