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
    public class LNSala: LNBiblioteca
    {

        public LNSala(): base()
        {
            
        }
        public bool AltaPrestamo(Prestamo prestamo)
        {
            return gbd.CrearPrestamo(prestamo);
        }

        public bool BajaPrestamo(string codigo)
        {
            return gbd.EliminarPrestamo(codigo);
        }
        public Ejemplar BuscarEjemplar(string cod)
        {
            return gbd.BuscarEjemplar(cod);
        }
        public bool ActualizarPrestamo(Prestamo prestamo)
        {
            return gbd.ActualizarPrestamo(prestamo);
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

        public List<Ejemplar> VerEjemplaresNoDevueltos()
        {
            List<Ejemplar> noDevueltos = new List<Ejemplar>();
            foreach (Ejemplar e in gbd.RecorrerEjemplares())
            {

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
            Prestamo prestamoBD = gbd.BuscarPrestamo(prestamo.Codigo);
            if (prestamoBD.Ejemplares.Count > 0)
            {
                finalizado = false;
            }
            if (finalizado)
            {
                prestamoBD.Estado = EstadoEnum.Finalizado;
                gbd.ActualizarPrestamo(prestamoBD); 
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

        public List<Prestamo> ObtenerPrestamosEnProceso()
        {
            List<Prestamo> resultado = new List<Prestamo>();
            foreach (Prestamo p in gbd.RecorrerPrestamos())
            {
                if (p.Estado == EstadoEnum.EnProceso)
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }
    }
}
