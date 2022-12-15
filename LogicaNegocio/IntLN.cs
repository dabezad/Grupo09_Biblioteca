using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal interface IntLN<C, O>
    {
        bool Alta(O o);
        bool Baja(C c);
        O Buscar(C c);
    }
}
