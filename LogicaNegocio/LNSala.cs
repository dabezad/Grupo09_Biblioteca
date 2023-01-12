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
        /// <summary>
        /// Da de alta un nuevo préstamo en la BD
        /// </summary>
        /// <param name="prestamo">Prestamo a introducir en la BD</param>
        /// <returns>True si se ha podido introducir el préstamo a la BD o false en caso contrario o si el préstamo es nulo</returns>
        public bool AltaPrestamo(Prestamo prestamo)
        {
            return gbd.CrearPrestamo(prestamo);
        }
        /// <summary>
        /// Da de baja definitivamente un préstamo de la BD
        /// </summary>
        /// <param name="codigo">Código del préstamo que se da de baja de la BD, que debe estar finalizado</param>
        /// <returns>True si se ha podido dar de baja correctamente o false en caso contrario o si el código no se corresponde con ningún préstamo finalizado de la BD</returns>
        public bool BajaPrestamo(string codigo)
        {
            return gbd.EliminarPrestamo(codigo);
        }
        /// <summary>
        /// Obtiene un Ejemplar de la BD a partir de su código
        /// </summary>
        /// <param name="cod">Código del ejemplar a buscar en la BD</param>
        /// <returns>El ejemplar con el que se corresponde el código o null si no se corresponde con ningún ejemplar de la BD</returns>
        public Ejemplar BuscarEjemplar(string cod)
        {
            return gbd.BuscarEjemplar(cod);
        }
        /// <summary>
        /// Actualiza un Préstamo existente de la BD
        /// </summary>
        /// <param name="prestamo">Préstamo a actualizar de la BD</param>
        /// <returns>True si se ha actualizado correctamente o false en caso contrario o si el préstamo no existía en la BD</returns>
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
        /// <summary>
        /// Obtiene los ejemplares de un préstamo que todavía no han sido devueltos
        /// </summary>
        /// <param name="prestamo">Préstamo del que se obtienen los ejemplares no devueltos. Debe estar en proceso</param>
        /// <returns>Lista con los ejemplares que todavía no han sido devueltos del préstamo en proceso</returns>
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
        /// <summary>
        /// Obtiene todos los ejemplares de la BD en estado prestado
        /// </summary>
        /// <returns>Lista con los ejemplares de la BD que se encuentren prestados actualmente</returns>
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
        /// <summary>
        /// Obtiene un objeto Prestamo de la BD a partir de su código
        /// </summary>
        /// <param name="id">Código del préstamo a buscar en la BD</param>
        /// <returns>Préstamo de la BD con el que se corresponde el código o null si no se ha podido encontrar</returns>
        public Prestamo BuscarPrestamo(string id)
        {
            return gbd.BuscarPrestamo(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Devuelve el ejemplar del préstamo actualizando sus datos en la BD. Si es el último ejemplar a devolver del préstamo, éste se pondrá a finalizado
        /// </summary>
        /// <param name="prestamo">Préstamo al que pertenece el ejemplar</param>
        /// <param name="ejemplar">Ejemplar a devolver</param>
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
        /// <summary>
        /// Obtiene todos los préstamos de la BD que todavía estén en proceso aunque su fecha de finalización haya sido superada
        /// </summary>
        /// <returns>Lista con los préstamos en proceso cuya fecha de finalización es menor a la de hoy</returns>
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
        /// Obtiene los libros que todavía no han sido devueltos a partir de un préstamo que está en proceso
        /// </summary>
        /// <param name="prestamo">Préstamo en proceso sobre el que se obtienen los libros no devueltos</param>
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
        /// <summary>
        /// Obtiene todos los préstamos de la BD que todavía se encuentren en proceso
        /// </summary>
        /// <returns>Lista con todos los préstamos cuyo estado sea en proceso</returns>
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

        public List<Prestamo> MostrarPrestamos()
        {
            return gbd.RecorrerPrestamos();
        }
    }
}
