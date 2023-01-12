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
        /// <summary>
        /// Inicializa la BD con datos de prueba
        /// </summary>
        public void CargarBD()
        {
            BD.LOAD(); 
        }
        /// <summary>
        /// Crea una nueva instancia de Libro en la BD
        /// </summary>
        /// <param name="l">Libro que se va a introducir en la BD</param>
        /// <returns>True si se ha creado correctamente o false en otro caso (o si el Libro es null)</returns>
        public bool CrearLibro(Libro l)
        {
            return BD.CREATE<string, LibroDato>(Transformadores.LibroADato(l));
        }
        /// <summary>
        /// Consigue un objeto Libro de la BD a partir de su isbn
        /// </summary>
        /// <param name="id">ISBN del Libro a buscar en la BD</param>
        /// <returns>El objeto Libro con el que se corresponde el isbn o null si no se corresponde con ningún libro de la BD</returns>
        public Libro BuscarLibro(string id)
        {
            return BD.READ<string, LibroDato>(id, "LibroDato") as Libro;
        }
        /// <summary>
        /// Actualiza una instancia de un Libro en la BD ya existente
        /// </summary>
        /// <param name="l">Libro con los datos a actualizar</param>
        /// <returns>True si el libro se ha actualizado correctamente en la BD o false en caso contrario o si el libro es nulo</returns>
        public bool ActualizarLibro(Libro l)
        {
            return BD.UPDATE<string, LibroDato>(Transformadores.LibroADato(l)); 
        }
        /// <summary>
        /// Elimina un libro existente en la BD a partir de su isbn
        /// </summary>
        /// <param name="id">ISBN del libro a eliminar en la BD</param>
        /// <returns>True si el libro se ha eliminado correctamente de la BD o false en caso contrario o si el isbn no se corresponde con ningún libro de la BD</returns>
        public bool EliminarLibro(string id)
        {
            return BD.DELETE<string, LibroDato>(id, "LibroDato");
        }
        /// <summary>
        /// Crea una nueva instancia de Ejemplar en la BD
        /// </summary>
        /// <param name="e">Ejemplar que se va a introducir en la BD</param>
        /// <returns>True si se ha creado correctamente o false en otro caso (o si el Ejemplar es null)</returns>
        public bool CrearEjemplar(Ejemplar e)
        {
            return BD.CREATE<string, EjemplarDato>(Transformadores.EjemplarADato(e));
        }
        /// <summary>
        /// Consigue un objeto Ejemplar de la BD a partir de su código
        /// </summary>
        /// <param name="id">Código del Ejemplar a buscar en la BD</param>
        /// <returns>El objeto Ejemplar con el que se corresponde el isbn o null si no se corresponde con ningún ejemplar de la BD</returns>
        public Ejemplar BuscarEjemplar(string id)
        {
            return BD.READ<string, EjemplarDato>(id, "EjemplarDato") as Ejemplar;
        }
        /// <summary>
        /// Actualiza una instancia de un Ejemplar en la BD ya existente
        /// </summary>
        /// <param name="e">Ejemplar con los datos a actualizar</param>
        /// <returns>True si el ejemplar se ha actualizado correctamente en la BD o false en caso contrario o si el ejemplar es nulo</returns>
        public bool ActualizarEjemplar(Ejemplar e)
        {
            return BD.UPDATE<string, EjemplarDato>(Transformadores.EjemplarADato(e));
        }
        /// <summary>
        /// Elimina un ejemplar existente en la BD a partir de su código
        /// </summary>
        /// <param name="id">Código del ejemplar a eliminar de la BD</param>
        /// <returns>True si el ejemplar se ha eliminado correctamente de la BD o false en caso contrario o si el código no se corresponde con ningún ejemplar de la BD</returns>
        public bool EliminarEjemplar(string id)
        {
            return BD.DELETE<string, EjemplarDato>(id, "EjemplarDato");
        }
        /// <summary>
        /// Crea una nueva instancia de Prestamo en la BD
        /// </summary>
        /// <param name="p">Prestamo a introducir en la BD</param>
        /// <returns>True si se ha creado correctamente o false en otro caso (o si el Prestamo es null)</returns>
        public bool CrearPrestamo(Prestamo p)
        {
            return BD.CREATE<string, PrestamoDato>(Transformadores.PrestamoADato(p));
        }
        /// <summary>
        ///  Consigue un objeto Prestamo de la BD a partir de su código
        /// </summary>
        /// <param name="id">Código del Prestamo a buscar en la BD</param>
        /// <returns>El objeto Prestamo con el que se corresponde el isbn o null si no se corresponde con ningún préstamo de la BD</returns>
        public Prestamo BuscarPrestamo(string id)
        {
            return BD.READ<string, PrestamoDato>(id, "PrestamoDato") as Prestamo;
        }
        /// <summary>
        /// Actualiza una instancia de un Prestamo en la BD ya existente
        /// </summary>
        /// <param name="p">Prestamo con los datos a actualizar</param>
        /// <returns>True si el prestamo se ha actualizado correctamente en la BD o false en caso contrario o si el prestamo es nulo</returns>
        public bool ActualizarPrestamo(Prestamo p)
        {
            return BD.UPDATE<string, PrestamoDato>(Transformadores.PrestamoADato(p));
        }
        /// <summary>
        /// Elimina un préstamo existente en la BD a partir de su código
        /// </summary>
        /// <param name="id">Código del préstamo a eliminar de la BD</param>
        /// <returns>True si el préstamo se ha eliminado correctamente de la BD o false en caso contrario o si el código no se corresponde con ningún préstamo de la BD</returns>
        public bool EliminarPrestamo(string id)
        {
            return BD.DELETE<string, PrestamoDato>(id, "PrestamoDato");
        }
        /// <summary>
        /// Crea una nueva instancia de PersonalBiblioteca en la BD
        /// </summary>
        /// <param name="p">PersonalBiblioteca a introducir en la BD</param>
        /// <returns>True si se ha creado correctamente o false en otro caso (o si el PersonalBiblioteca es null)</returns>
        public bool CrearPersonal(PersonalBiblioteca p)
        {
            return BD.CREATE<string, PersonalBibliotecaDato>(Transformadores.PersonalADato(p));
        }
        /// <summary>
        /// Consigue un objeto PersonalBiblioteca de la BD a partir de su nombre
        /// </summary>
        /// <param name="id">Nombre del PersonalBiblioteca a buscar en la BD</param>
        /// <returns>El objeto PersonalBiblioteca con el que se corresponde el isbn o null si no se corresponde con ningún personal de la BD</returns>
        public PersonalBiblioteca BuscarPersonal(string id)
        {
            return BD.READ<string, PersonalBibliotecaDato>(id, "PersonalBibliotecaDato") as PersonalBiblioteca;
        }
        /// <summary>
        /// Actualiza una instancia de un PersonalBiblioteca en la BD ya existente
        /// </summary>
        /// <param name="p">PersonalBiblioteca con los datos a actualizar</param>
        /// <returns>True si el personal se ha actualizado correctamente en la BD o false en caso contrario o si el personal es nulo</returns>
        public bool ActualizarPersonal(PersonalBiblioteca p)
        {
            return BD.UPDATE<string, PersonalBibliotecaDato>(Transformadores.PersonalADato(p));

        }
        /// <summary>
        /// Elimina un personal existente en la BD a partir de su nombre
        /// </summary>
        /// <param name="id">Nombre del usuario a eliminar de la BD</param>
        /// <returns>True si el personal se ha eliminado correctamente de la BD o false en caso contrario o si el nombre no se corresponde con ningún personal de la BD</returns>
        public bool EliminarPersonal(string id)
        {
            return BD.DELETE<string, PersonalBibliotecaDato>(id, "PersonalBibliotecaDato");
        }
        /// <summary>
        /// Crea una nueva instancia de Usuario en la BD
        /// </summary>
        /// <param name="u">Usuario a introducir en la BD</param>
        /// <returns>True si se ha creado correctamente o false en otro caso (o si el Usuario es null)</returns>
        public bool CrearUsuario(Usuario u)
        {
            return BD.CREATE<string, UsuarioDato>(Transformadores.UsuarioADato(u));
        }
        /// <summary>
        /// Consigue un objeto Usuario de la BD a partir de su código
        /// </summary>
        /// <param name="id">Dni del Usuario a buscar en la BD</param>
        /// <returns>El objeto Usuario con el que se corresponde el isbn o null si no se corresponde con ningún usuario de la BD</returns>
        public Usuario BuscarUsuario(string id)
        {
            return BD.READ<string, UsuarioDato>(id, "UsuarioDato") as Usuario;
        }
        /// <summary>
        /// Actualiza una instancia de un Usuario en la BD ya existente
        /// </summary>
        /// <param name="u">Usuario con los datos a actualizar</param>
        /// <returns>True si el usuario se ha actualizado correctamente en la BD o false en caso contrario o si el usuario es nulo</returns>
        public bool ActualizarUsuario(Usuario u)
        {
            return BD.UPDATE<string, UsuarioDato>(Transformadores.UsuarioADato(u));
        }
        /// <summary>
        /// Elimina un usuario existente en la BD a partir de su dni
        /// </summary>
        /// <param name="id">Dni del usuario a eliminar de la BD</param>
        /// <returns>True si el usuario se ha eliminado correctamente de la BD o false en caso contrario o si el dni no se corresponde con ningún usuario de la BD</returns>
        public bool EliminarUsuario(string id)
        {
            return BD.DELETE<string, UsuarioDato>(id, "UsuarioDato");
        }
        /// <summary>
        /// Crea una lista de los usuarios existentes en la BD
        /// </summary>
        /// <returns>Una lista de todos los objetos Usuario de la BD</returns>
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
        /// <summary>
        /// Crea una lista de los libros existentes en la BD
        /// </summary>
        /// <returns>Una lista de todos los objetos Libro de la BD</returns>
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
        /// <summary>
        /// Crea una lista de los préstamos actuales (activos o no) existentes en la BD
        /// </summary>
        /// <returns>Una lista de todos los objetos Prestamo de la BD</returns>
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
        /// <summary>
        /// Crea una lista de los ejemplares actuales existentes en la BD
        /// </summary>
        /// <returns>Una lista de todos los objetos Ejemplar de la BD</returns>
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
        /// <summary>
        /// Crea una lista de los ejemplares en préstamos actuales existentes en la BD
        /// </summary>
        /// <returns>Una lista de todos los objetos EjemplarEnPrestamo de la BD</returns>
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
