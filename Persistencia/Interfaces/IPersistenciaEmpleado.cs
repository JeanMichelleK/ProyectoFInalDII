﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        Empleado Buscar(string pUsu, Empleado pUsuario);
        Empleado Logueo(string pUsu, string pPass);
    }
}
