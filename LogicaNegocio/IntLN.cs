﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal interface IntLN
    {
        bool Alta<T>(T t);
        bool Baja<T>(T t);
        bool Buscar<T>();
    }
}
