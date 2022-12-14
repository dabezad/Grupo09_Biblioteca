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
        private static Tabla<string, PersonalBibliotecaDato> tPersonalBiblioteca;

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
        public static Tabla<string, PersonalBibliotecaDato> TPersonalBiblioteca
        {
            get { return tPersonalBiblioteca; }
        }

        public static bool CREATE<U, T>(U u) where U: Entity<T>
        {
            bool hecho = true;
            if (t is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Add(ud);
            }
            if (t is Prestamo)
            {
                PrestamoDato pm = Transformadores.PrestamoADato(t as Prestamo);
                BD.TPrestamo.Add(pm);
            }
            if (t is Ejemplar)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Add(ud);
            }
            if (t is Libro)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Add(ud);
            }
            if (t is PersonalBiblioteca)
            {
                PersonalBibliotecaDato pb = Transformadores.PersonalADato(t as PersonalBiblioteca);
                BD.TPersonalBiblioteca.Add(pb);
            }//en caso de no funcionar añadir 3 if con los distintos personales

            return hecho;
        }

        public static T READ<T, U>(string id)
        {

        }

        public static bool UPDATE<T>(T t) where T: Entity<string>
        {
            return true;
        }

        public static bool DELETE<T>(T t) where T: Entity<string>
        {
            if (t is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Remove(ud);
                return true;
            }
            if (t is Prestamo)
            {
                PrestamoDato pm = Transformadores.PrestamoADato(t as Prestamo);
                BD.TPrestamo.Remove(pm);
            }
            if (t is Ejemplar)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Remove(ud);
            }
            if (t is Libro)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(t as Usuario);
                BD.TUsuario.Remove(ud);
            }
            if (t is PersonalBiblioteca)
            {
                PersonalBibliotecaDato pb = Transformadores.PersonalADato(t as PersonalBiblioteca);
                BD.TPersonalBiblioteca.Remove(pb);
            }//en caso de no funcionar añadir 3 if con los distintos personales

           

            return false;
        }

        

    }
}
