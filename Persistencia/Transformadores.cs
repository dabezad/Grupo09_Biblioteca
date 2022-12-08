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
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre, u.PersonalBAlta);
            return ud;
        }

        public static Usuario DatoAUsuario(UsuarioDato ud)
        {
            Usuario u = new Usuario(ud.Dni, ud.Nombre, ud.PersonalBAlta);
            return u;
        }

        public static EjemplarDato EjemplarADato(Ejemplar e)
        {
            EjemplarDato ed = new EjemplarDato(e.Codigo, e.Estado, e.Libro.Isbn, e.PersonalBAlta);
            return ed;
        }

        public static Ejemplar DatoAEjemplar(EjemplarDato ed)
        {
            Ejemplar e = new Ejemplar(ed.Codigo, ed.Estado, null, ed.PersonalBAlta); //CAMBIAR NULL POR NEW LIBRO
            return e;                                                               // CUANDO SE IMPLEMENTE
        }

        public static LibroDato LibroADato(Libro l)
        {
            LibroDato ld = new LibroDato(l.Isbn, l.Titulo, l.Autor, l.Editorial, l.PersonalBAlta);
            return ld;
        }

        public static Libro DatoALibro(LibroDato ld)
        {
            Libro l = new Libro(ld.Isbn, ld.Titulo, ld.Autor, ld.Editorial, ld.PersonalBAlta);
            return l;
        }

        public static PrestamoDato PrestamoADato(Prestamo p)
        {
            String[] n = new string[p.Ejemplares.Length];
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = p.Ejemplares[i].Codigo;
            }
            PrestamoDato pd = new PrestamoDato(p.Codigo, p.Usuario.Dni, n, p.FRealizado, p.FFinPrestamo, p.Estado, p.PersonalBAlta);
            return pd; //CAMBIAR NULL POR NEW USUARIO Y NEW EJEMPLARES[] CUANDO SE IMPLEMENTE
        }

        public static Prestamo DatoAPrestamo(PrestamoDato pd)
        {
            Prestamo p = new Prestamo(pd.Codigo, null, null, pd.FRealizado, pd.FFinPrestamo,  pd.PersonalBAlta);
            return p;
        }

        public static PersonalBibliotecaDato PersonalADato(PersonalBiblioteca p)
        {
            PersonalBibliotecaDato pd = new PersonalBibliotecaDato(p.Nombre, p.Contraseña);
            return pd;
        }

        public static PersonalBiblioteca DatoAPersonal(PersonalBibliotecaDato pd)
        {
            PersonalBiblioteca p = new PersonalBiblioteca(pd.Nombre, pd.Contraseña);
            return p;
        }
    }
}
