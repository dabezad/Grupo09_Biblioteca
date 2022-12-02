using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal static class Transformadores
    {
        public static UsuarioDato UsuarioADato(Usuario u)
        {
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre);
            return ud;
        }
    }
}
