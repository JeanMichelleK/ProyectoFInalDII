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
        void Alta(Cliente unC, Empleado pUsu);
        void Modificar(Cliente unC, Empleado pUsu);
        void Baja(Cliente unC, Empleado pUsu);
        Cliente BuscarClienteActivo(string pPasaporte, Empleado pUsu);
    }
}
