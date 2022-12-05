using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal class BD
    {
        private static Tabla<string, LibroDato> tLibro;
        private static Tabla<string, EjemplarDato> tEjemplar;
        private static Tabla<string, UsuarioDato> tUsuario;
        private static Tabla<string, PrestamoDato> tPrestamo;

        private BD()
        {

        }

        public static Tabla<string, LibroDato> TLibro
        {
            get { return tLibro; }
        }

        public static Tabla<string, EjemplarDato> TEjemplar
        {
            get { return tEjemplar; }   
        }

        public static Tabla<string, UsuarioDato> TUsuario
        {
            get { return tUsuario; }
        }

        public static Tabla<string, PrestamoDato> TPrestamo
        {
            get { return tPrestamo;  }
        }

        public static bool CREATE<T>(T t) where T: Entity<string>
        {
            bool hecho = true;
            if (t is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Add(ud);
            }
            return hecho;
        }

        public static bool DELETE<T>(T t) where T: Entity<string>
        {

        }

        public static T SEARCH<T>(string id)
        {

        }


    }
}
