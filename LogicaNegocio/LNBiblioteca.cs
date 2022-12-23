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
            var presJUsu = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u) && p.Estado == EstadoEnum.EnProceso); //Es necesario crear el objeto EjemplarEnPrestamo para la consulta
            var l =
                from prestamos in presJUsu
                join eeps in gbd.RecorrerEEP() on prestamos.Codigo equals eeps.CodPr
                join ejemplares in gbd.RecorrerEjemplares() on eeps.CodEj equals ejemplares.Codigo
                where ejemplares.Estado == EstadoEjemplarEnum.Prestado
                select ejemplares;
            return new List<Ejemplar>(l); //Otra tryhardeada masiva (esta aun mas)

            
        }

        public List<Prestamo> MostrarPrestamosCaducados(Usuario u)
        {
            var l = gbd.RecorrerPrestamos().Where((p) => p.Usuario.Equals(u)).Where((p) => DateTime.Compare(DateTime.Now, p.FFinPrestamo) > 0 && p.Estado == EstadoEnum.EnProceso);
            return new List<Prestamo>(l); 
        }

    }
}
