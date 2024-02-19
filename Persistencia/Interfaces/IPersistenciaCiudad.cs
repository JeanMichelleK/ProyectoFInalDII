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
        void Alta(Ciudad unaC);

        void Modificar(Ciudad unaC);

        void Baja(Ciudad unaC);

        Ciudad BuscarCiudadActiva(string pCodigo);
    }
}
