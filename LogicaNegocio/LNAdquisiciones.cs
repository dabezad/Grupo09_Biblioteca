﻿using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class LNAdquisiciones : LNBiblioteca
    {
        private GestorBD gbd;

        public LNAdquisiciones()
        {
            gbd = new GestorBD();
        }
        public bool AltaLibro(Libro l)
        {
            return gbd.CrearLibro(l);
        }

        public bool BajaLibro(string id)
        {
            return gbd.EliminarLibro(id);
        }

        public bool AltaEjemplar(Ejemplar e)
        {
            return gbd.CrearEjemplar(e);
        }

        public bool BajaEjemplar(string id)
        {
            return gbd.EliminarEjemplar(id);
        }

        public Libro BuscarLibro(string isbn)
        {
            return gbd.BuscarLibro(isbn);
        }

        public Ejemplar BuscarEjemplar(string codigo)
        {
            return gbd.BuscarEjemplar(codigo);
        }

        public List<Ejemplar> EjemplaresDisponibles(string isbn)
        {
            List<Ejemplar> ejemplares = gbd.RecorrerEjemplares();
            List<Ejemplar> res = new List<Ejemplar>();
            foreach (Ejemplar e in ejemplares)
            {
                if (e.Estado == EstadoEjemplarEnum.Disponible)
                {
                    res.Add(e);
                }
            }
            return res;
        }

        public DateTime MostrarFechaDevolucion(Ejemplar e, Prestamo p) 
        {
            return p.FFinPrestamo;
        }

        public  ListarEjemplares(string isbn)
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
