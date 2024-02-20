using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    internal class Conexion
    {
        internal static string Cnn(Empleado pUsu = null)
        {
            if (pUsu == null)
                return "Data Source =.; Initial Catalog = ProyectoFinal; Integrated Security = true";
            else
                return "Data Source =.; Initial Catalog = ProyectoFinal; User=" + pUsu.Usuario + "; Password='" + pUsu.Contraseña + "'";
        }
    }
}
