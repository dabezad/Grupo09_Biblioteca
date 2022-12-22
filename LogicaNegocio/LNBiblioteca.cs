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
            var presJUsu = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u)); //Es necesario crear el objeto EjemplarEnPrestamo para la consulta
            var l = 
                from prestamos in presJUsu
                join ejemplares in gbd.RecorrerEEP() on prestamos.Codigo equals ejemplares.

            
        }

        public List<Prestamo> MostrarPrestamosCaducados(Usuario u)
        {
            var l = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u)).Where((p) => DateTime.Compare(DateTime.Now, p.FFinPrestamo) > 0 && p.Estado == EstadoEnum.EnProceso);
            return new List<Prestamo>(l); //Tryhardeada masiva
        }

    }
}
