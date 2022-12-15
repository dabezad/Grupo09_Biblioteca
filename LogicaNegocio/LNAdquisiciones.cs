﻿using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class LNAdquisiciones : IntLN<string, Libro>
    {
        private GestorBD gbd;

        public LNAdquisiciones()
        {
            gbd = new GestorBD();
        }
        public bool Alta(Libro l)
        {
            return gbd.CrearLibro(l);
        }

        public bool Baja(Libro l)
        {
            return gbd.EliminarLibro();
        }

        public bool AltaEjemplar(Ejemplar e)
        {
            return gbd.CrearEjemplar(e);
        }

        public bool BajaEjemplar(Ejemplar e)
        {
            return gbd.EliminarEjemplar(e);
        }

        public Libro Buscar(string isbn)
        {
            return gbd.BuscarLibro(isbn);
        }

        public Ejemplar BuscarEjemplar(string codigo)
        {
            return gbd.BuscarEjemplar(codigo);
        }

        public Ejemplar[] EjemplaresDisponibles(string isbn)
        {

        }

        public DateTime MostrarFechaDevolucion(Ejemplar e, Prestamo p) 
        {
            return p.FFinPrestamo;
        }

        public Ejemplar[] ListarEjemplares(string isbn)
        {

        }

        public Libros[] ListarLibros()
        {

        }

        public Libro MostrarLibroMasLeido()
        {

        }
    }
}