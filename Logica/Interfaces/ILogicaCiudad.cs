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
        void Alta(Ciudad unaC);
        void Modificar(Ciudad unaC);
        void Baja(Ciudad unaC);
        Ciudad Buscar(string pCodigoC);

    }
}
