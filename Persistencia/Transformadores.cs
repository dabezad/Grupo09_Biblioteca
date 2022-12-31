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
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre, u.PersonalBAlta.Nombre);
            return ud;
        }

        public static Usuario DatoAUsuario(UsuarioDato ud)
        {
            Usuario u = new Usuario(ud.Dni, ud.Nombre, BD.READ<string, PersonalBibliotecaDato>(ud.PersonalBAlta, "PersonalBibliotecaDato") as PersonalBiblioteca);
            return u;
        }

        public static EjemplarDato EjemplarADato(Ejemplar e)
        {
            EjemplarDato ed = new EjemplarDato(e.Codigo, e.Estado, e.Libro.Isbn, e.PersonalBAlta.Nombre);
            return ed;
        }

        public static Ejemplar DatoAEjemplar(EjemplarDato ed)
        {
            Ejemplar e = new Ejemplar(ed.Codigo, ed.Estado, BD.READ<string, LibroDato>(ed.Libro, "LibroDato") as Libro, BD.READ<string, PersonalBibliotecaDato>(ed.PersonalBAlta, "PersonalBibliotecaDato") as PersonalAdquisiciones); 
            return e;                                                               
        }

        public static LibroDato LibroADato(Libro l)
        {
            LibroDato ld = new LibroDato(l.Isbn, l.Titulo, l.Autor, l.Editorial, l.PersonalBAlta.Nombre);
            return ld;
        }

        public static Libro DatoALibro(LibroDato ld)
        {
            Libro l = new Libro(ld.Isbn, ld.Titulo, ld.Autor, ld.Editorial, BD.READ<string, PersonalBibliotecaDato>(ld.PersonalBAlta, "PersonalBibliotecaDato") as PersonalAdquisiciones);
            return l;
        }

        public static PrestamoDato PrestamoADato(Prestamo p)
        {
            PrestamoDato pd = new PrestamoDato(p.Codigo, p.Usuario.Dni, p.FRealizado, p.FFinPrestamo, p.Estado, p.PersonalBAlta.Nombre);
            foreach (Ejemplar e in p.Ejemplares)
            {
                bool existe = false;
                foreach(EjemplarEnPrestamoDato eepd in BD.TEEP.ToList()) 
                {
                    if (eepd.CodEjemplar == e.Codigo)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    BD.UPDATE<string, EjemplarDato>(new EjemplarDato(e.Codigo, EstadoEjemplarEnum.Prestado, e.Libro.Isbn, e.PersonalBAlta.Nombre)); //El ejemplar se pone a prestado
                    BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(new EjemplarEnPrestamoDato(p.Codigo, e.Codigo)); //Se crea la instancia de la tabla intermedia correspondiente
                }
            }
            return pd;
        
        
        }

        public static Prestamo DatoAPrestamo(PrestamoDato pd)
        {
            
            List<Ejemplar> ejemplares = new List<Ejemplar>();
            foreach (EjemplarEnPrestamoDato elem in BD.TEEP.ToList())
            {
                if (elem.Id.CodPres == pd.Codigo)
                {
                    Ejemplar e = BD.READ<string, EjemplarDato>(elem.Id.CodEjem, "EjemplarDato") as Ejemplar;
                    ejemplares.Add(e);
                }
            }
            Prestamo p = new Prestamo(pd.Codigo, BD.READ<string, UsuarioDato>(pd.Usuario, "UsuarioDato") as Usuario, ejemplares, pd.FRealizado, pd.FFinPrestamo, pd.Estado, BD.READ<string, PersonalBibliotecaDato>(pd.PersonalBAlta,"PersonalBibliotecaDato") as PersonalSala);

            return p;
        }

        public static PersonalBibliotecaDato PersonalADato(PersonalBiblioteca p)
        {
            PersonalBibliotecaDato pd = new PersonalBibliotecaDato(p.Nombre, p.Contraseña, p.GetType().Name);
            return pd;
        }

        public static PersonalBiblioteca DatoAPersonal(PersonalBibliotecaDato pd)
        {
            PersonalBiblioteca p = null;
            if (pd.Tipo == "PersonalBiblioteca")
            {
                p = new PersonalBiblioteca(pd.Nombre, pd.Contraseña);
            }
            else if (pd.Tipo == "PersonalAdquisiciones")//aca mierdon
            {
                p = new PersonalAdquisiciones(pd.Nombre, pd.Contraseña);
            }
            else if(pd.Tipo == "PersonalSala")
            {
                p = new PersonalSala(pd.Nombre, pd.Contraseña);
            }
            return p;
        }
        

        public static PersonalAdquisiciones DatoAPersonalAdq(PersonalBibliotecaDato pd)
        {
            return new PersonalAdquisiciones(pd.Id, pd.Contraseña);
        }

        public static PersonalSala DatoAPersonalSala(PersonalBibliotecaDato pd)
        {
            return new PersonalSala(pd.Id, pd.Contraseña);
        }

        public static EjemplarEnPrestamo DatoAEEP(EjemplarEnPrestamoDato datoEEP)
        {
            EjemplarEnPrestamo eep = new EjemplarEnPrestamo(datoEEP.CodPrestamo, datoEEP.CodEjemplar);
            return eep;
        }
    }
}
