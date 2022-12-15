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
    internal class LNSala
    {
        private GestorBD gbd;

        public LNSala()
        {
            gbd = new GestorBD();
        }
        public bool Alta(Prestamo prestamo)
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
            int i = 0;
            List<Ejemplar> noDevueltos = new List<Ejemplar>();
            List<Ejemplar> prestados = prestamo.Ejemplares.ToList();
            foreach(Ejemplar e in prestados)
            {
                if (e.Estado == EstadoEnum.EnProceso)
                {
                    noDevueltos.Add(e);
                }
            }
            return noDevueltos;
        }

        public Prestamo VerDatosPrestamo(string id)
        {
            return gbd.BuscarPrestamo(id);
        }

        public List<Prestamo> ObtenerPrestamosLibro(Libro l)
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            foreach (Prestamo p in gbd.RecorrerPrestamos())
            {
                if (p.Ejemplares)
            }
        }

        public void DevolverEjemplarPrestado(Ejemplar ejemplar)
        {
            ejemplar.Estado = EstadoEnum.Finalizado;
        }

        public Prestamo[] ObtenerPrestamosEnProcesoPasados()
        {
                
        }

        public List<Libro> VerLibrosNoDevueltos(Prestamo prestamo)
        {
            List<Libro> lista1 = gbd.RecorrerLibros();
            List<Libro> res = new List<Libro>();
            foreach(Libro l in lista1)
            {
                if (l.)
            }
            
            
            return list;
        }
    }
}
