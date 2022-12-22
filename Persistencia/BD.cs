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
        public static bool CREATE<T, U>(U u) where U: Entity<T>
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

        public static object READ<T, U>(T t, string tabla) where U : Entity<T>
        {
            if (t == null) return null;
            object x = null;
            switch (tabla)
            {
                case "UsuarioDato":
                    if (BD.TUsuario.Contains(t as string)) x = Transformadores.DatoAUsuario(BD.TUsuario[t as string]);
                    break;
                case "PrestamoDato":
                    if (BD.TPrestamo.Contains(t as string)) x = Transformadores.DatoAPrestamo(BD.TPrestamo[t as string]);
                    break;
                case "EjemplarDato":
                    if (BD.TEjemplar.Contains(t as string)) x = Transformadores.DatoAEjemplar(BD.TEjemplar[t as string]);
                    break;
                case "LibroDato":
                    if (BD.TLibro.Contains(t as string)) x = Transformadores.DatoALibro(BD.TLibro[t as string]);
                    break;
                case "PersonalBibliotecaDato":
                    if (BD.TPersonalBiblioteca.Contains(t as string)) x = Transformadores.DatoAPersonal(BD.TPersonalBiblioteca[t as string]);
                    break;
                case "EjemplarEnPrestamoDato":
                    if (BD.TEjemplarEnPrestamo.Contains(t as ClaveEEP)) x = Transformadores.DatoAPersonal(BD.TEjemplarEnPrestamo[t as ClaveEEP]);
                    break;//aca mierdon
            }
            return x;
        }

        public static bool UPDATE<T, U>(U u) where U : Entity<T>
        {
            bool b = false;
            if (u == null)
            {
                b = false;
            }
            if (u is Usuario)
            {
                UsuarioDato ud = Transformadores.UsuarioADato(u as Usuario);
                String s = ud.Dni;
                if ((BD.READ<string, UsuarioDato>(s, "UsuarioDato") != null))
                {
                    BD.DELETE<string, UsuarioDato>(s, "UsuarioDato");
                    BD.CREATE<string, UsuarioDato>(ud);
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            if (u is Prestamo)
            {
                PrestamoDato ud = Transformadores.PrestamoADato(u as Prestamo);
                String s = ud.Codigo;
                if ((BD.READ<string, PrestamoDato>(s, "PrestamoDato") != null))
                {
                    BD.DELETE<string, PrestamoDato>(s, "PrestamoDato");
                    BD.CREATE<string, PrestamoDato>(ud);
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            if (u is Ejemplar)
            {
                EjemplarDato ud = Transformadores.EjemplarADato(u as Ejemplar);
                String s = ud.Codigo;
                if ((BD.READ<string, EjemplarDato>(s, "EjemplarDato") != null))
                {
                    BD.DELETE<string, EjemplarDato>(s, "EjemplarDato");
                    BD.CREATE<string, EjemplarDato>(ud);
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            if (u is Libro)
            {
                LibroDato ud = Transformadores.LibroADato(u as Libro);
                String s = ud.Isbn;
                if ((BD.READ<string, LibroDato>(s, "LibroDato") != null))
                {
                    BD.DELETE<string, LibroDato>(s, "LibroDato");
                    BD.CREATE<string, LibroDato>(ud);
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            if (u is PersonalBiblioteca)
            {
                PersonalBibliotecaDato ud = Transformadores.PersonalADato(u as PersonalBiblioteca);
                String s = ud.Nombre;
                if ((BD.READ<string, PersonalBibliotecaDato>(s, "PersonalBibliotecaDato") != null))
                {
                    BD.DELETE<string, PersonalBibliotecaDato>(s, "PersonalBibliotecaDato");
                    BD.CREATE<string, PersonalBibliotecaDato>(ud);
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            return b;
        }

        public static bool DELETE<T, U>(T t, string nombre) where U: Entity<T>
        {
            
        }

    }
}
