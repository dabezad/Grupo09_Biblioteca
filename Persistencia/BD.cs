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
        private static Tabla<string, LibroDato> tLibro = new Tabla<string, LibroDato>();
        private static Tabla<string, EjemplarDato> tEjemplar = new Tabla<string, EjemplarDato>();
        private static Tabla<string, UsuarioDato> tUsuario = new Tabla<string, UsuarioDato>();
        private static Tabla<string, PrestamoDato> tPrestamo = new Tabla<string, PrestamoDato>();
        private static Tabla<string, PersonalBibliotecaDato> tPersonalBiblioteca = new Tabla<string, PersonalBibliotecaDato>();
        private static Tabla<ClaveEEP, EjemplarEnPrestamoDato> tEjemplarEnPrestamo = new Tabla<ClaveEEP, EjemplarEnPrestamoDato>();

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
        public static bool CREATE<T, U>(U u) where U : Entity<T>
        {
            if (u == null)
            {
                return false;
            }
            else
            if (u is UsuarioDato)
            {

                BD.TUsuario.Add(u as UsuarioDato);
                return true;
            }
            else
            if (u is PrestamoDato)
            {
                Prestamo p = Transformadores.DatoAPrestamo(u as PrestamoDato);
                foreach (Ejemplar e in p.Ejemplares)
                {
                    BD.TEjemplarEnPrestamo.Add(new EjemplarEnPrestamoDato(p.Codigo, e.Codigo));
                }
                BD.TPrestamo.Add(u as PrestamoDato);
                return true;
            }
            else
            if (u is EjemplarDato)
            {

                BD.TEjemplar.Add(u as EjemplarDato);
                return true;
            }
            else
            if (u is LibroDato)
            {

                BD.TLibro.Add(u as LibroDato);
                return true;
            }
            else
            if (u is PersonalBibliotecaDato)
            {

                BD.TPersonalBiblioteca.Add(u as PersonalBibliotecaDato);
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
                /*case "EjemplarEnPrestamoDato":
                    if (BD.TEjemplarEnPrestamo.Contains(t as ClaveEEP)) x = Transformadores.DatoAPersonal(BD.TEjemplarEnPrestamo[t as ClaveEEP]);
                    break;//aca mierdon*/
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
            else if (u is UsuarioDato)
            {
                UsuarioDato ud = u as UsuarioDato;
                if ((BD.READ<string, UsuarioDato>(ud.Dni, "UsuarioDato") != null))
                {
                    BD.DELETE<string, UsuarioDato>(ud.Dni, "UsuarioDato");
                    BD.CREATE<string, UsuarioDato>(ud);
                    b = true;
                }
            }
            else if (u is PrestamoDato) //Comprobar ejemplares con el previo elemento de la tabla
            {
                PrestamoDato ud = u as PrestamoDato;
                if ((BD.READ<string, PrestamoDato>(ud.Codigo, "PrestamoDato") != null))
                {
                    BD.DELETE<string, PrestamoDato>(ud.Codigo, "PrestamoDato");
                    BD.CREATE<string, PrestamoDato>(ud);
                    b = true;
                }
                
            }
            else if (u is EjemplarDato)
            {
                EjemplarDato ud = u as EjemplarDato;
                if ((BD.READ<string, EjemplarDato>(ud.Codigo, "EjemplarDato") != null))
                {
                    BD.DELETE<string, EjemplarDato>(ud.Codigo, "EjemplarDato");
                    BD.CREATE<string, EjemplarDato>(ud);
                    b = true;
                }
            }
            else if (u is LibroDato)
            {
                LibroDato ud = u as LibroDato;
                if ((BD.READ<string, LibroDato>(ud.Isbn, "LibroDato") != null))
                {
                    BD.DELETE<string, LibroDato>(ud.Isbn, "LibroDato");
                    BD.CREATE<string, LibroDato>(ud);
                    b = true;
                }
            }
            else if (u is PersonalBibliotecaDato)
            {
                PersonalBibliotecaDato ud = u as PersonalBibliotecaDato;
                if ((BD.READ<string, PersonalBibliotecaDato>(ud.Id, "PersonalBibliotecaDato") != null))
                {
                    BD.DELETE<string, PersonalBibliotecaDato>(ud.Id, "PersonalBibliotecaDato");
                    BD.CREATE<string, PersonalBibliotecaDato>(ud);
                    b = true;
                }
            }
            return b;
        }


        public static bool DELETE<T, U>(T t, string tabla) where U : Entity<T>
        {
            switch (tabla)
            {
                case "UsuarioDato":
                    UsuarioDato ud = BD.READ<string, UsuarioDato>(t as string, "UsuarioDato") as UsuarioDato;
                    return BD.TUsuario.Remove(ud);

                case "PrestamoDato":
                    PrestamoDato pd = BD.READ<string, PrestamoDato>(t as string, "PrestamoDato") as PrestamoDato;
                    foreach (EjemplarEnPrestamoDato elem in BD.TEjemplarEnPrestamo.ToList())
                    {
                        if (elem.Id.CodPres == pd.Codigo)
                        {
                            BD.TEjemplarEnPrestamo.Remove(elem);
                        }
                    }
                    return BD.TPrestamo.Remove(pd);
                case "EjemplarDato":
                    EjemplarDato ed = BD.READ<string, EjemplarDato>(t as string, "EjemplarDato") as EjemplarDato;
                    return BD.TEjemplar.Remove(ed);

                case "LibroDato":
                    LibroDato ld = BD.READ<string, LibroDato>(t as string, "LibroDato") as LibroDato;
                    return BD.TLibro.Remove(ld);

                case "PersonalBibliotecaDato":
                    PersonalBibliotecaDato pbd = BD.READ<string, PersonalBibliotecaDato>(t as string, "PersonalBibliotecaDato") as PersonalBibliotecaDato;
                    return BD.TPersonalBiblioteca.Remove(pbd);
            }
            return false;


        }
    }
}
