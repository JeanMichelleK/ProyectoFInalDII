using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaCiudad
    {
        void Alta(Ciudad unaC, Empleado pUsu);
        void Modificar(Ciudad unaC, Empleado pUsu);
        void Baja(Ciudad unaC, Empleado pUsu);
        Ciudad Buscar(string pCodigoC, Empleado pUsu);
        List<Ciudad> ListadoCiudades(Empleado pUsu);

    }
}
