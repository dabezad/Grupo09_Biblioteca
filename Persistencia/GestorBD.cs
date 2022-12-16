using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class GestorBD
    {
        public GestorBD()
        {

        }

        public bool CrearLibro(Libro l)
        {
            return BD.CREATE<string, LibroDato>(l);
        }
        
        public Libro BuscarLibro(string id)
        {
            return BD.READ<string, LibroDato>(id);
        }

        public bool ActualizarLibro()
        {

        }


        public bool EliminarLibro(string id)
        {
            return BD.DELETE<string, LibroDato>(id);
        }

        public bool CrearEjemplar(Ejemplar e)
        {
            return BD.CREATE<string, EjemplarDato>(e);
        }
        public Ejemplar BuscarEjemplar(string id)
        {
            return BD.READ<string, EjemplarDato>(id);
        }
        public bool ActualizarEjemplar()
        {

        }
        public bool EliminarEjemplar(string id)
        {
            return BD.DELETE<string, EjemplarDato>(id);
        }
        public bool CrearPrestamo(Prestamo p)
        {
            return BD.CREATE<string, PrestamoDato>(p);
        }
        public Prestamo BuscarPrestamo(string id)
        {
            return BD.READ<string, PrestamoDato>(id);
        }
        public bool ActualizarPrestamo()
        {

        }
        public bool EliminarPrestamo(string id)
        {
            return BD.DELETE<string, PrestamoDato>(id);
        }
        public bool CrearPersonal(PersonalBiblioteca p)
        {
            return BD.CREATE<string, PersonalBibliotecaDato>(p);
        }
        public PersonalBiblioteca BuscarPersonal(string id)
        {
            return BD.READ<string, PersonalBibliotecaDato>(id);
        }
        public bool ActualizarPersonal()
        {

        }
        public bool EliminarPersonal(string id)
        {
            return BD.DELETE<string, PersonalBibliotecaDato>(id);
        }
        public bool CrearUsuario(Usuario u)
        {
            return BD.CREATE<string, UsuarioDato>(u);
        }
        public Usuario BuscarUsuario(string id)
        {
            return BD.READ<string, UsuarioDato>(id);
        }
        public bool ActualizarUsuario()
        {

        }
        public bool EliminarUsuario(string id)
        {
            return BD.DELETE<string, UsuarioDato>(id);
        }

        public List<Usuario> RecorrerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            List<UsuarioDato> listaDatos = BD.TUsuario.ToList<UsuarioDato>();
            foreach (UsuarioDato dato in listaDatos)
            {
                lista.Add(Transformadores.DatoAUsuario(dato));
            }
            return lista;
        }

        public List<Libro> RecorrerLibros()
        {
            List<Libro> listaL = new List<Libro>();
            List<LibroDato> listaLDatos = BD.TLibro.ToList<LibroDato>();
            foreach(LibroDato datoL in listaLDatos)
            {
                listaL.Add(Transformadores.DatoALibro(datoL));
            }
            return listaL;
        }

        public List<Prestamo> RecorrerPrestamos()
        {
            List<Prestamo> listaP = new List<Prestamo>();
            List<PrestamoDato> listaPDatos = BD.TPrestamo.ToList<PrestamoDato>();
            foreach(PrestamoDato datoP in listaPDatos)
            {
                listaP.Add(Transformadores.DatoAPrestamo(datoP));
            }
            return listaP;
        }

        public List<Ejemplar> RecorrerEjemplares()
        {
            List<Ejemplar> listaE = new List<Ejemplar>();
            List<EjemplarDato> listaEDatos = BD.TEjemplar.ToList<EjemplarDato>();
            foreach(EjemplarDato datoE in listaEDatos)
            {
                listaE.Add(Transformadores.DatoAEjemplar(datoE));
            }
            return listaE;
        }

        public List<Ejemplar> PrestamoJoinEjemplar(string idP)
        {
            List<EjemplarEnPrestamoDato> ejemplaresDelPrestamo = new List<EjemplarEnPrestamoDato>();
            List<Ejemplar> ejemplares = RecorrerEjemplares();
            List<Ejemplar> resultado = new List<Ejemplar>();
            int i;
            bool encontrado;
            foreach(EjemplarEnPrestamoDato elem in BD.TEjemplarEnPrestamo.ToList())
            {
                if (elem.Id.CodPres == idP)
                {
                    ejemplaresDelPrestamo.Add(elem);
                }
            }
            foreach(EjemplarEnPrestamoDato eep in ejemplaresDelPrestamo)
            {
                i = 0;
                encontrado = false;
                while (!encontrado)
                {
                    if (eep.Id.CodEjem == ejemplares.ElementAt(i).Codigo)
                    {
                        resultado.Add(ejemplares.ElementAt(i));
                        encontrado = true;
                    }
                    i++;
                } 
            }
            return resultado;
        }

        public List<Prestamo> EjemplarJoinPrestamo(string idE)
        {
            List<Prestamo> prestamos = RecorrerPrestamos();
            List<EjemplarEnPrestamoDato> prestamosDelEjemplar = new List<EjemplarEnPrestamoDato>();
            List<Prestamo> resultado = new List<Prestamo>();
            int i;
            bool encontrado;
            foreach (EjemplarEnPrestamoDato elem in BD.TEjemplarEnPrestamo.ToList())
            {
                if (elem.Id.CodEjem == idE)
                {
                    prestamosDelEjemplar.Add(elem);
                }
            }
            foreach (EjemplarEnPrestamoDato eep in prestamosDelEjemplar)
            {
                i = 0;
                encontrado = false;
                while (!encontrado)
                {
                    if (eep.Id.CodPres == prestamos.ElementAt(i).Codigo)
                    {
                        resultado.Add(prestamos.ElementAt(i));
                        encontrado = true;
                    }
                    i++;
                }
            }
            return resultado;
        }



    }
}
