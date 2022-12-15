using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class LNAdquisiciones
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

        public bool BajaLibro(Libro l)
        {
            return gbd.EliminarLibro(l);
        }

        public bool AltaEjemplar(Ejemplar e)
        {
            return gbd.CrearEjemplar(e);
        }

        public bool BajaEjemplar(Ejemplar e)
        {
            return gbd.EliminarEjemplar(e);
        }

        public Libro BuscarLibro(string isbn)
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
