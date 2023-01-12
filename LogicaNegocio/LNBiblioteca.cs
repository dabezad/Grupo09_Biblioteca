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

        public bool AltaUsuario(Usuario usuario)
        {
            return gbd.CrearUsuario(usuario);
        }
        public bool AltaPersonal(PersonalBiblioteca personal) 
        {
            return gbd.CrearPersonal(personal);
        }

        public PersonalBiblioteca BuscarPersonal(string nombre)
        {
            return gbd.BuscarPersonal(nombre);
        }

        public bool BajaUsuario(string id)
        {
            return gbd.EliminarUsuario(id);
        }

        public Usuario BuscarUsuario(string id)
        {
            return gbd.BuscarUsuario(id);
        }

        public List<Usuario> MostrarUsuarios()
        {
            return gbd.RecorrerUsuarios();
        }

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

        public List<Prestamo> MostrarPrestamosCaducados(Usuario u)
        {
            var l = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u)).Where((p) => DateTime.Compare(DateTime.Now, p.FFinPrestamo) > 0 && p.Estado == EstadoEnum.EnProceso);
            return new List<Prestamo>(l); 
        }

        public List<Ejemplar> ObtenerEjemplaresDePrestamo(string codP)
        {
            var eeps = gbd.RecorrerEEP().Where((eep) => eep.CodPr == codP);
            var l =
                from prestamos in eeps
                join ejemplares in gbd.RecorrerEjemplares() on prestamos.CodEj equals ejemplares.Codigo
                select ejemplares;
            return new List<Ejemplar>(l);

        }

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
