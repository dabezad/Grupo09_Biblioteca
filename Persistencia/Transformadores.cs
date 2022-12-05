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
        public static UsuarioDato UsuarioADato(Usuario u, string personal)
        {
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre, u.PersonalBAlta);
            return ud;
        }

        public static Usuario DatoAUsuario(UsuarioDato ud)
        {
            Usuario u = new Usuario(ud.Dni, ud.Nombre, ud.PersonalBAlta);
            return u;
        }

        public static EjemplarDato EjemplarADato(Ejemplar e, string personal)
        {
            EjemplarDato ed = new EjemplarDato(e.)
            return ed;
        }
    }
}
