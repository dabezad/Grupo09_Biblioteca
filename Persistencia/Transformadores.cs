﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal static class Transformadores
    {
        /// <summary>
        /// Transforma un objeto Usuario a un elemento UsuarioDato de la BD
        /// </summary>
        /// <param name="u">Usuario a convertir a UsuarioDato</param>
        /// <returns>El elemento UsuarioDato transformado a partir del objeto Usuario pasado por parámetro</returns>
        public static UsuarioDato UsuarioADato(Usuario u)
        {
            UsuarioDato ud = new UsuarioDato(u.Dni, u.Nombre, u.PersonalBAlta.Nombre);
            return ud;
        }
        /// <summary>
        /// Transforma un elemento UsuarioDato de la BD a un objeto Usuario
        /// </summary>
        /// <param name="ud">UsuarioDato de la BD a convertir a Usuario</param>
        /// <returns>El objeto Usuario transformado a partir del elemento UsuarioDato pasado por parámetro</returns>
        public static Usuario DatoAUsuario(UsuarioDato ud)
        {
            Usuario u = new Usuario(ud.Dni, ud.Nombre, BD.READ<string, PersonalBibliotecaDato>(ud.PersonalBAlta, "PersonalBibliotecaDato") as PersonalBiblioteca);
            return u;
        }
        /// <summary>
        /// Transforma un objeto Ejemplar a un elemento EjemplarDato de la BD
        /// </summary>
        /// <param name="e">Ejemplar a convertir a EjemplarDato</param>
        /// <returns>El elemento EjemplarDato transformado a partir del objeto Ejemplar pasado por parámetro</returns>
        public static EjemplarDato EjemplarADato(Ejemplar e)
        {
            EjemplarDato ed = new EjemplarDato(e.Codigo, e.Estado, e.Libro.Isbn, e.PersonalBAlta.Nombre);
            return ed;
        }
        /// <summary>
        /// Transforma un elemento EjemplarDato de la BD a un objeto Ejemplar
        /// </summary>
        /// <param name="ed">EjemplarDato de la BD a convertir a Ejemplar</param>
        /// <returns>El objeto Ejemplar transformado a partir del elemento EjemplarDato pasado por parámetro</returns>
        public static Ejemplar DatoAEjemplar(EjemplarDato ed)
        {
            Ejemplar e = new Ejemplar(ed.Codigo, ed.Estado, BD.READ<string, LibroDato>(ed.Libro, "LibroDato") as Libro, BD.READ<string, PersonalBibliotecaDato>(ed.PersonalBAlta, "PersonalBibliotecaDato") as PersonalAdquisiciones); 
            return e;                                                               
        }
        /// <summary>
        /// Transforma un objeto Libro a un elemento LibroDato de la BD
        /// </summary>
        /// <param name="l">Libro a convertir a LibroDato</param>
        /// <returns>El elemento LibroDato transformado a partir del objeto Libro pasado por parámetro</returns>
        public static LibroDato LibroADato(Libro l)
        {
            LibroDato ld = new LibroDato(l.Isbn, l.Titulo, l.Autor, l.Editorial, l.PersonalBAlta.Nombre);
            return ld;
        }
        /// <summary>
        /// Transforma un elemento LibroDato de la BD a un objeto Libro
        /// </summary>
        /// <param name="ld">LibroDato de la BD a convertir a Libro</param>
        /// <returns>El objeto Libro transformado a partir del elemento LibroDato pasado por parámetro</returns>
        public static Libro DatoALibro(LibroDato ld)
        {
            Libro l = new Libro(ld.Isbn, ld.Titulo, ld.Autor, ld.Editorial, BD.READ<string, PersonalBibliotecaDato>(ld.PersonalBAlta, "PersonalBibliotecaDato") as PersonalAdquisiciones);
            return l;
        }
        /// <summary>
        /// Transforma un objeto Prestamo a un elemento PrestamoDato de la BD
        /// </summary>
        /// <param name="p">Prestamo a convertir a PrestamoDato</param>
        /// <returns>El elemento PrestamoDato transformado a partir del objeto Prestamo pasado por parámetro</returns>
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
        /// <summary>
        /// Transforma un elemento PrestamoDato de la BD a un objeto Prestamo
        /// </summary>
        /// <param name="pd">PrestamoDato de la BD a convertir a Prestamo</param>
        /// <returns>El objeto Prestamo transformado a partir del elemento PrestamoDato pasado por parámetro</returns>
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
        /// <summary>
        /// Transforma un objeto PersonalBiblioteca a un elemento PersonalBibliotecaDato   
        /// </summary>
        /// <param name="p">PersonalBiblioteca a convertir a PersonalBibliotecaDato</param>
        /// <returns>El elemento PersonalBibliotecaDato transformado a partir del objeto PersonalBiblioteca pasado por parámetro</returns>
        public static PersonalBibliotecaDato PersonalADato(PersonalBiblioteca p)
        {
            PersonalBibliotecaDato pd = new PersonalBibliotecaDato(p.Nombre, p.Contraseña, p.GetType().Name);
            return pd;
        }
        /// <summary>
        /// Transforma un elemento PersonalBibliotecaDato de la BD a un objeto PersonalBiblioteca
        /// </summary>
        /// <param name="pd">PersonalBibliotecaDato de la BD a convertir a PersonalBiblioteca</param>
        /// <returns>El objeto PersonalBiblioteca transformado a partir del elemento PersonalBibliotecaDato pasado por parámetro</returns>
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

        /// <summary>
        /// Transforma un elemento PersonalBibliotecaDato de la BD a un objeto PersonalAdquisiciones
        /// </summary>
        /// <param name="pd">PersonalBibliotecaDato de la BD a convertir a PersonalAdquisiciones</param>
        /// <returns>El objeto PersonalAdquisiciones transformado a partir del elemento PersonalBibliotecaDato pasado por parámetro</returns>
        public static PersonalAdquisiciones DatoAPersonalAdq(PersonalBibliotecaDato pd)
        {
            return new PersonalAdquisiciones(pd.Id, pd.Contraseña);
        }
        /// <summary>
        /// Transforma un elemento PersonalBibliotecaDato de la BD a un objeto PersonalSala
        /// </summary>
        /// <param name="pd">PersonalBibliotecaDato de la BD a convertir a PersonalSala</param>
        /// <returns>El objeto PersonalSala transformado a partir del elemento PersonalBibliotecaDato pasado por parámetro</returns>
        public static PersonalSala DatoAPersonalSala(PersonalBibliotecaDato pd)
        {
            return new PersonalSala(pd.Id, pd.Contraseña);
        }
        /// <summary>
        /// Transforma un elemento EjemplarEnPrestamoDato de la BD a un objeto EjemplarEnPrestamo
        /// </summary>
        /// <param name="datoEEP">EjemplarEnPrestamoDato de la BD a convertir a EjemplarEnPrestamo</param>
        /// <returns>El objeto EjemplarEnPrestamo transformado a partir del elemento EjemplarEnPrestamoDato pasado por parámetro</returns>
        public static EjemplarEnPrestamo DatoAEEP(EjemplarEnPrestamoDato datoEEP)
        {
            EjemplarEnPrestamo eep = new EjemplarEnPrestamo(datoEEP.CodPrestamo, datoEEP.CodEjemplar);
            return eep;
        }
    }
}
