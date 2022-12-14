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
        private static Tabla<ClaveEEP, EjemplarEnPrestamoDato> tEjemplarEnPrestamo;

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

        public static Tabla<ClaveEEP, EjemplarEnPrestamoDato> TEjemplarEnPrestamo { 
            get { return tEjemplarEnPrestamo; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Clave de tabla U</typeparam>
        /// <typeparam name="U">Dato tipo Tabla con clave T</typeparam>
        /// <param name="u"></param>
        /// <returns></returns>
        public static bool CREATE<T, U>(object u) where U: Entity<T>
        {
            if (u == null)
            {
                return false;
            }
            if ( u is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(u as Usuario);
                BD.TUsuario.Add(ud);
                return true;
            }
            if (u is Prestamo)
            {
                Prestamo p = u as Prestamo;
                PrestamoDato pm = Transformadores.PrestamoADato(p);
                foreach(Ejemplar e in p.Ejemplares)
                {
                    BD.TEjemplarEnPrestamo.Add(new EjemplarEnPrestamoDato(p.Codigo, e.Codigo)); 
                }
                BD.TPrestamo.Add(pm);
                return true;
            }
            if (u is Ejemplar)
            {
                EjemplarDato ed = Transformadores.EjemplarADato(u as Ejemplar);
                BD.TEjemplar.Add(ed);
                return true;
            }
            if (u is Libro)
            {
                LibroDato ld= Transformadores.LibroADato(u as Libro);
                BD.TLibro.Add(ld);
                return true;
            }
            if (u is PersonalBiblioteca)
            {
                PersonalBibliotecaDato pb = Transformadores.PersonalADato(u as PersonalBiblioteca);
                BD.TPersonalBiblioteca.Add(pb);
                return true;
            }//en caso de no funcionar añadir 3 if con los distintos personales
            return false;
        }

        public static object READ<T, U>(T t, U u) where U : Entity<T>
        {
            if(t == null) return null;
            if(u == null) return null;
            if (u is UsuarioDato)
            {
                Usuario us=Transformadores.DatoAUsuario(BD.TUsuario[t as string]);
                return us;
            }
            if (u is PrestamoDato)
            {
                Prestamo ps = Transformadores.DatoAPrestamo(BD.TPrestamo[t as string]);

            }
            if (u is EjemplarDato)
            {
                Ejemplar ej = Transformadores.DatoAEjemplar(BD.TEjemplar[t as string]);
            }
            if (u is LibroDato)
            {
                Libro lb = Transformadores.DatoALibro(BD.TLibro[t as string]);
            }
            if (u is PersonalBibliotecaDato)
            {
                PersonalBiblioteca pb = Transformadores.DatoAPersonal(BD.TPersonalBiblioteca[t as string]);
            }
            return null;
        }

        public static bool UPDATE<T>(T t, object) where T: Entity<string>
        {
            return true;
        }

        public static bool DELETE<T, U>(T t, U u) where U: Entity<T>
        {
            if (u is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(u as Usuario);
                BD.TUsuario.Remove(ud);
                return true;
            }
            if (u is Prestamo)
            {
                PrestamoDato pm = Transformadores.PrestamoADato(u as Prestamo);
                BD.TPrestamo.Remove(pm);
            }
            if (u is Ejemplar)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(u as Usuario);
                BD.TUsuario.Remove(ud);
            }
            if (u is Libro)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(u as Usuario);
                BD.TUsuario.Remove(ud);
            }
            if (u is PersonalBiblioteca)
            {
                PersonalBibliotecaDato pb = Transformadores.PersonalADato(u as PersonalBiblioteca);
                BD.TPersonalBiblioteca.Remove(pb);
            }//en caso de no funcionar añadir 3 if con los distintos personales

           

            return false;
        }

        

    }
}
