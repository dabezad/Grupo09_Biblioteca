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
            Usuario u = new Usuario(ud.Dni, ud.Nombre, BD.READ<string, PersonalBibliotecaDato>(ud.PersonalBAlta));
            return u;
        }

        public static EjemplarDato EjemplarADato(Ejemplar e)
        {
            EjemplarDato ed = new EjemplarDato(e.Codigo, e.Estado, e.Libro.Isbn, e.PersonalBAlta.Nombre);
            return ed;
        }

        public static Ejemplar DatoAEjemplar(EjemplarDato ed)
        {
            Ejemplar e = new Ejemplar(ed.Codigo, ed.Estado, BD.READ<string, LibroDato>(ed.Libro, ), BD.READ<string, PersonalBibliotecaDato>(e.PersonalBAlta)); 
            return e;                                                               
        }

        public static LibroDato LibroADato(Libro l)
        {
            LibroDato ld = new LibroDato(l.Isbn, l.Titulo, l.Autor, l.Editorial, l.PersonalBAlta.Nombre);
            return ld;
        }

        public static Libro DatoALibro(LibroDato ld)
        {
            Libro l = new Libro(ld.Isbn, ld.Titulo, ld.Autor, ld.Editorial, BD.READ<string, PersonalBibliotecaDato>(ld.PersonalBAlta, ld));
            return l;
        }

        public static PrestamoDato PrestamoADato(Prestamo p)
        {
            PrestamoDato pd = new PrestamoDato(p.Codigo, p.Usuario.Dni, p.FRealizado, p.FFinPrestamo, p.Estado, p.PersonalBAlta.Nombre);
            
            return pd;
        
        
        }

        public static Prestamo DatoAPrestamo(PrestamoDato pd)
        {
            Prestamo p = new Prestamo(pd.Codigo, BD.READ<string, UsuarioDato>(pd.Usuario, "UsuarioDato") as Usuario, null, pd.FRealizado, pd.FFinPrestamo,  BD.READ<string, PersonalBibliotecaDato>(pd.PersonalBAlta,"PersonalBibliotecaDato") as PersonalSala);
            EjemplarEnPrestamoDato //esto se lia fuertemente
            foreach(BD.READ<ClaveEEP, "EjemeplarEnPrestamoDato"> in )
            return p;
        }

        public static PersonalBibliotecaDato PersonalADato(PersonalBiblioteca p)
        {
            PersonalBibliotecaDato pd = new PersonalBibliotecaDato(p.Nombre, p.Contraseña, p.GetType().Name);
            return pd;
        }

        public static PersonalBiblioteca DatoAPersonal(PersonalBibliotecaDato pd)
        {
            PersonalBiblioteca p = new PersonalBiblioteca(pd.Nombre, pd.Contraseña);
            return p;
        }
    }
}
