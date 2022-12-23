using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
                if (e.Libro.Isbn == isbn && e.Estado == EstadoEjemplarEnum.Disponible)
                {
                    res.Add(e);
                }
            }
            return res;
        }

        public DateTime MostrarFechaDevolucion(Prestamo p) 
        {
            return p.FFinPrestamo;
        }

        public List<Ejemplar> ListarEjemplares(string isbn)
        {
            List<Ejemplar> ejemplarDeLibro = new List<Ejemplar>();
            foreach(Ejemplar e in gbd.RecorrerEjemplares())
            {
                if (isbn == e.Libro.Isbn)
                {
                    ejemplarDeLibro.Add(e);
                }
            }
            return ejemplarDeLibro;
        }

        public List<Libro> ListarLibros()
        {
            return gbd.RecorrerLibros();
        }

        public Libro MostrarLibroMasLeido()
        {
            var l =
                from eeps in gbd.RecorrerEEP()
                join prestamos in gbd.RecorrerPrestamos() on eeps.CodPr equals prestamos.Codigo
                group eeps by prestamos into gr
                orderby gr.Count() descending
                select gr.Key;  //Ordena los eeps por prestamos 
            Prestamo p = l.First(); //Consigo el primer prestamo (que contiene el libro mas solicitado)
            EjemplarEnPrestamo eep = gbd.RecorrerEEP().Where((ep) => ep.CodPr == p.Codigo).First(); //Voy sacando el libro mediante busquedas
            Ejemplar l2 = gbd.RecorrerEjemplares().Where((ej) => ej.Codigo == eep.CodEj).First(); //de Prestamo -> EEP -> Ejemplar -> Libro
            Libro masLeido = gbd.RecorrerLibros().Where((lib) => l2.Libro.Isbn == lib.Isbn).First();
            return masLeido;
        }
    }
}
