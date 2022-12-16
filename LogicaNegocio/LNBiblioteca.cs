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

    public class LNBiblioteca 
    {
        private GestorBD gbd;

        public LNBiblioteca()
        {
            gbd = new GestorBD();
        }
        public bool AltaUsuario(Usuario usuario)
        {
            return gbd.CrearUsuario(usuario);
        }

        public bool BajaUsuario(string id)
        {
            return gbd.EliminarUsuario(id);
        }

        public Usuario BuscarUsuario(string id)
        {
            return gbd.BuscarUsuario(id);
        }

        public List<Usuario> MostrarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            return lista;
        }

        public List<Ejemplar> MostrarEjemplaresPrestados(Usuario u) 
        {
            List<Prestamo> listaPrestamos = gbd.RecorrerPrestamos();
            List<Ejemplar> listaEjemplares = gbd.RecorrerEjemplares();
            List<EjemplarEnPrestamoDato> ejemplaresPrestamo = gbd.
            List<Prestamo> prestamosDelUsuario = new List<Prestamo>();
            foreach(Prestamo p in listaPrestamos){
                if (p.Usuario.Equals(u))
                {
                    prestamosDelUsuario.Add(p);
                }
            }
        }

        public List<Prestamo> MostrarPrestamosCaducados()
        {
            List<Prestamo> todosPrestamos = gbd.RecorrerPrestamos();
            List<Prestamo> res;
            foreach (Prestamo p in todosPrestamos)
            {
                
            }
        }

    }
}
