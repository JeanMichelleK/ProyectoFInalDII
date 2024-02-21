using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaVenta
    {
        void Alta(Venta unaV, Empleado pUsu);
        List<Venta> VentaVuelo(string pCodigoV, Empleado pUsu);
    }
}
