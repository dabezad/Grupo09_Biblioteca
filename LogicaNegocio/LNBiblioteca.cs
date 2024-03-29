﻿using ModeloDominio;
using Persistencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{

    public class LNBiblioteca 
    {
        protected GestorBD gbd;

        public LNBiblioteca()
        {
            gbd = new GestorBD();
        }
        /// <summary>
        /// Carga los datos iniciales en la BD
        /// </summary>
        public void IniciarBD()
        {
            gbd.CargarBD();
        }

        /// <summary>
        /// Da de alta un usuario en la bd
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve true si se ha dado de alta correctamente al usuario, false si no</returns>
        public bool AltaUsuario(Usuario usuario)
        {
            return gbd.CrearUsuario(usuario);
        }

        /// <summary>
        /// Da de alta un personal en la bd
        /// </summary>
        /// <param name="personal"></param>
        /// <returns>Devuelve true si se ha dado de alta correctamente al personal, false si no</returns>
        public bool AltaPersonal(PersonalBiblioteca personal) //Método para el botón registrar del login
        {
            return gbd.CrearPersonal(personal);
        }

        /// <summary>
        /// Dado un nombre devuelve un personal
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Devuelve el objeto con el personal</returns>
        public PersonalBiblioteca BuscarPersonal(string nombre)
        {
            return gbd.BuscarPersonal(nombre);
        }

        /// <summary>
        /// Da de baja un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>devuelve true si el usuario se ha dado de baja, false si no</returns>
        public bool BajaUsuario(string id)
        {
            return gbd.EliminarUsuario(id);
        }

        /// <summary>
        /// Dado un id devuelve un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>devuelve el usuario</returns>
        public Usuario BuscarUsuario(string id)
        {
            return gbd.BuscarUsuario(id);
        }

        /// <summary>
        /// Devuelve una lista con los usuarios
        /// </summary>
        /// <returns>Devuelve una lista con los usuarios</returns>
        public List<Usuario> MostrarUsuarios()
        {
            return gbd.RecorrerUsuarios();
        }

        /// <summary>
        /// Devuelve una lista con los ejemplares prestados
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>Devuelve una lista con los ejemplares prestados</returns>
        public Libro BuscarLibro(string isbn)
        {
            return gbd.BuscarLibro(isbn);
        }

        /// <summary>
        /// Muestra los ejemplares que tiene prestados actualmente el usuario u
        /// </summary>
        /// <param name="u">Usuario del que se quieren obtener los ejemplares prestados</param>
        /// <returns>Lista de ejemplares que tiene prestados el usuario</returns>
        public List<Ejemplar> MostrarEjemplaresPrestados(Usuario u) 
        {
            var presJUsu = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u) && p.Estado == EstadoEnum.EnProceso); //Es necesario crear el objeto EjemplarEnPrestamo para la consulta
            var resjoin = 
                from eeps in gbd.RecorrerEEP()
                join pres in presJUsu on eeps.CodPr equals pres.Codigo
                select eeps;
            var l =
                from ejemplares in gbd.RecorrerEjemplares()
                join eep in resjoin on ejemplares.Codigo equals eep.CodEj 
                where ejemplares.Estado == EstadoEjemplarEnum.Prestado
                select ejemplares;
            return new List<Ejemplar>(l); 

            
        }

        /// <summary>
        /// Devuelve una lista con los prestamos caducados
        /// </summary>
        /// <param name="u"></param>
        /// <returns>Devuelve una lista con los prestamos caducados</returns>
        public List<Prestamo> MostrarPrestamosCaducados(Usuario u)
        {
            var l = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u)).Where((p) => DateTime.Compare(DateTime.Now, p.FFinPrestamo) > 0 && p.Estado == EstadoEnum.EnProceso);
            return new List<Prestamo>(l); 
        }

        /// <summary>
        /// Devuelve una lista con los ejmpalres de un prestamo
        /// </summary>
        /// <param name="codP"></param>
        /// <returns>Devuelve una lista con los ejmpalres de un prestamo</returns>
        public List<Ejemplar> ObtenerEjemplaresDePrestamo(string codP)
        {
            var eeps = gbd.RecorrerEEP().Where((eep) => eep.CodPr == codP);
            var l =
                from prestamos in eeps
                join ejemplares in gbd.RecorrerEjemplares() on prestamos.CodEj equals ejemplares.Codigo
                select ejemplares;
            return new List<Ejemplar>(l);

        }
        /// <summary>
        /// Obtiene el préstamo al que pertenece un ejemplar prestado
        /// </summary>
        /// <param name="e">Ejemplar en estado Prestado del que se quiere obtener el préstamo al que pertenece</param>
        /// <returns>Prestamo al que pertenece el ejemplar</returns>
        public Prestamo ObtenerPrestamoDeEjemplar(Ejemplar e)
        {
            var eeps = gbd.RecorrerEEP().Where((eep) => eep.CodEj == e.Codigo);
            var l =
                from ejemplares in eeps
                join prestamos in gbd.RecorrerPrestamos() on ejemplares.CodPr equals prestamos.Codigo
                select prestamos;
            return new List<Prestamo>(l).First();
        }
    }
}
