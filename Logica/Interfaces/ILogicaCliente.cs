﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaCliente
    {
        void Alta(Cliente unC);
        void Modificar(Cliente unC);
        void Baja(Cliente unC);
        Cliente Buscar(string pNroPasaporte);
    }
}
