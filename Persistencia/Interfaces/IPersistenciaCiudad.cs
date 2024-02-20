using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaCiudad
    {
        void Alta(Ciudad unaC, Empleado pUsu);

        void Modificar(Ciudad unaC, Empleado pUsu);

        void Baja(Ciudad unaC, Empleado pUsu);

        Ciudad BuscarCiudadActiva(string pCodigo, Empleado pUsu);
    }
}
