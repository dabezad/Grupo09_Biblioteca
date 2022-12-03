using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal static class Transformadores
    {
        public static UsuarioDato UsuarioADato(Usuario u)
        {
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre);
            return ud;
        }

        public static Usuario DatoAUsuario(UsuarioDato ud)
        {
            
        }

        public static EjemplarDato EjemplarADato(Ejemplar e)
        {
            EjemplarDato ed = new EjemplarDato(e.)
        }
    }
}
