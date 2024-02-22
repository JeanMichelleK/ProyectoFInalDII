using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaEmpleado
    {
        Empleado Buscar(string pUsu, Empleado pUsuario);
        Empleado Logueo(string pUsu, string pPass);
    }
}
