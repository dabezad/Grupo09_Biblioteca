using ModeloDominio;
using Persistencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class LNSala: LNBiblioteca
    {
        private GestorBD gbd;

        public LNSala()
        {
            gbd = new GestorBD();
        }
        public bool AltaPrestamo(Prestamo prestamo)
        {
            return gbd.CrearPrestamo(prestamo);
        }

        public Usuario VerInformacionUsuario(Prestamo prestamo)
        {
            return prestamo.Usuario;
        }

        public Enum VerEstadoPrestamo(Prestamo prestamo)
        {
            return prestamo.Estado;
        }

        public List<Ejemplar> VerEjemplaresNoDevueltos(Prestamo prestamo)
        {
            List<Ejemplar> noDevueltos = new List<Ejemplar>();
            foreach(Ejemplar e in prestamo.Ejemplares.ToList()) { 
            
                if (e.Estado == EstadoEjemplarEnum.Prestado)
                {
                    noDevueltos.Add(e);
                }
            }
            return noDevueltos;
        }

        public Prestamo BuscarPrestamo(string id)
        {
            return gbd.BuscarPrestamo(id);
        }

        public List<Prestamo> ObtenerPrestamosLibro(Libro l)
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            foreach (Prestamo p in gbd.RecorrerPrestamos())
            {
                foreach(Ejemplar e in p.Ejemplares.ToList())
                {
                    if (e.Libro.Isbn == l.Isbn && !prestamos.Contains(p))
                    {
                        prestamos.Add(p);
                    }
                }
            }
            return prestamos;
        }

        public void DevolverEjemplarPrestado(Prestamo prestamo, Ejemplar ejemplar)
        {
            bool finalizado = true;
            ejemplar.Estado = EstadoEjemplarEnum.Disponible;
            gbd.ActualizarEjemplar(ejemplar);
            foreach (Ejemplar e in prestamo.Ejemplares)
            {
                if (finalizado && e.Estado == EstadoEjemplarEnum.Prestado)
                {
                    finalizado = false;
                }
            }
            if (finalizado)
            {
                prestamo.Estado = EstadoEnum.Finalizado;
                gbd.ActualizarPrestamo(prestamo); 
            }
            
        }

        public List<Prestamo> ObtenerPrestamosEnProcesoPasados()
        {
            List<Prestamo> resultado = new List<Prestamo>();
            foreach(Prestamo p in gbd.RecorrerPrestamos())
            {
                if ((DateTime.Compare(DateTime.Now, p.FFinPrestamo) > 0) && (p.Estado == EstadoEnum.EnProceso))
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestamo">Debe estar en proceso</param>
        /// <returns>Lista con libros del préstamo que todavía no han sido devueltos</returns>
        public List<Libro> VerLibrosNoDevueltos(Prestamo prestamo)
        {
            var prestamoT = gbd.RecorrerPrestamos().Where((p) => p.Codigo == prestamo.Codigo);
            var l =
                from prestamos in prestamoT
                join eeps in gbd.RecorrerEEP() on prestamos.Codigo equals eeps.CodPr
                join ejemplares in gbd.RecorrerEjemplares() on eeps.CodEj equals ejemplares.Codigo
                join libros in gbd.RecorrerLibros() on ejemplares.Libro.Isbn equals libros.Isbn
                where ejemplares.Estado == EstadoEjemplarEnum.Prestado
                select libros;
            return new List<Libro>(l);
        }
    }
}
