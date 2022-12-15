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

        public Ejemplar[] VerEjemplaresNoDevueltos(Prestamo prestamo)
        {
            int i = 0;
            Ejemplar[] noDevueltos = new Ejemplar[prestamo.Ejemplares.Length];
            Ejemplar[] prestados = prestamo.Ejemplares;
            foreach(Ejemplar e in prestados)
            {
                if (e.Estado == EstadoEnum.EnProceso)
                {
                    noDevueltos[i] = e;
                    i++;
                }
            }
            return noDevueltos;
        }

        public Prestamo VerDatosPrestamo(string id)
        {
            return gbd.BuscarPrestamo(id);
        }

        public Prestamo[] ObtenerPrestamosLibro(Libro l)
        {
            
        }

        public void devolverEjemplarPrestado(Ejemplar ejemplar)
        {
            ejemplar.Estado = EstadoEnum.Finalizado;
        }

        public Prestamo[] ObtenerPrestamosEnProcesoPasados()
        {

        }

        public List<Libro> VerLibrosNoDevueltos(Prestamo prestamo)
        {
            List<Libro> list = new List<Libro>;
            Ejemplar[] prestados = prestamo.Ejemplares;
            foreach (Ejemplar e in prestados)
            {
                if (e.Estado == EstadoEnum.EnProceso)
                {
                    Libro libro = e.Libro;
                    if (!list.Contains(libro))
                    {
                        list.Add(libro);
                    }
                }
            }
            return list;
        }
    }
}
