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

        public void CargarBD()
        {
            BD.LOAD(); //Inicializa la BD con datos de prueba
        }

        public bool CrearLibro(Libro l)
        {
            return BD.CREATE<string, LibroDato>(Transformadores.LibroADato(l));
        }
        
        public Libro BuscarLibro(string id)
        {
            return BD.READ<string, LibroDato>(id, "LibroDato") as Libro;
        }

        public bool ActualizarLibro(Libro l)
        {
            return BD.UPDATE<string, LibroDato>(Transformadores.LibroADato(l)); 
        }


        public bool EliminarLibro(string id)
        {
            return BD.DELETE<string, LibroDato>(id, "LibroDato");
        }

        public bool CrearEjemplar(Ejemplar e)
        {
            return BD.CREATE<string, EjemplarDato>(Transformadores.EjemplarADato(e));
        }
        public Ejemplar BuscarEjemplar(string id)
        {
            return BD.READ<string, EjemplarDato>(id, "EjemplarDato") as Ejemplar;
        }
        public bool ActualizarEjemplar(Ejemplar e)
        {
            return BD.UPDATE<string, EjemplarDato>(Transformadores.EjemplarADato(e));
        }
        public bool EliminarEjemplar(string id)
        {
            return BD.DELETE<string, EjemplarDato>(id, "EjemplarDato");
        }
        public bool CrearPrestamo(Prestamo p)
        {
            return BD.CREATE<string, PrestamoDato>(Transformadores.PrestamoADato(p));
        }
        public Prestamo BuscarPrestamo(string id)
        {
            return BD.READ<string, PrestamoDato>(id, "PrestamoDato") as Prestamo;
        }
        public bool ActualizarPrestamo(Prestamo p)
        {
            return BD.UPDATE<string, PrestamoDato>(Transformadores.PrestamoADato(p));
        }
        public bool EliminarPrestamo(string id)
        {
            return BD.DELETE<string, PrestamoDato>(id, "PrestamoDato");
        }
        public bool CrearPersonal(PersonalBiblioteca p)
        {
            return BD.CREATE<string, PersonalBibliotecaDato>(Transformadores.PersonalADato(p));
        }
        public PersonalBiblioteca BuscarPersonal(string id)
        {
            return BD.READ<string, PersonalBibliotecaDato>(id, "PersonalBibliotecaDato") as PersonalBiblioteca;
        }
        public bool ActualizarPersonal(PersonalBiblioteca p)
        {
            return BD.UPDATE<string, PersonalBibliotecaDato>(Transformadores.PersonalADato(p));

        }
        public bool EliminarPersonal(string id)
        {
            return BD.DELETE<string, PersonalBibliotecaDato>(id, "PersonalBibliotecaDato");
        }
        public bool CrearUsuario(Usuario u)
        {
            return BD.CREATE<string, UsuarioDato>(Transformadores.UsuarioADato(u));
        }
        public Usuario BuscarUsuario(string id)
        {
            return BD.READ<string, UsuarioDato>(id, "UsuarioDato") as Usuario;
        }
        public bool ActualizarUsuario(Usuario u)
        {
            return BD.UPDATE<string, UsuarioDato>(Transformadores.UsuarioADato(u));
        }
        public bool EliminarUsuario(string id)
        {
            return BD.DELETE<string, UsuarioDato>(id, "UsuarioDato");
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
            List<EjemplarDato> listaEDatos = BD.TEjemplar.ToList();
            foreach(EjemplarDato datoE in listaEDatos)
            {
                listaE.Add(Transformadores.DatoAEjemplar(datoE));
            }
            return listaE;
        }

        public List<EjemplarEnPrestamo> RecorrerEEP()
        {
            List<EjemplarEnPrestamo> res = new List<EjemplarEnPrestamo>();
            List<EjemplarEnPrestamoDato> listaEEPDatos = BD.TEEP.ToList();
            foreach (EjemplarEnPrestamoDato datoEEP in listaEEPDatos)
            {
                res.Add(Transformadores.DatoAEEP(datoEEP));
            }
            return res;
        }
        
        



    }
}
