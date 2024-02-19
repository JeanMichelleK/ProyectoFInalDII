using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaCliente
    {
        void Alta(Cliente unC);
        void Modificar(Cliente unC);
        void Baja(Cliente unC);
        Cliente BuscarClienteActivo(string pPasaporte);
    }
}
