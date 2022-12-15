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

    public class LNBiblioteca : IntLN<string, Usuario>
    {
        private GestorBD gbd;

        public LNBiblioteca()
        {
            gbd = new GestorBD();
        }
        public bool Alta(Usuario usuario)
        {
            return gbd.CrearUsuario(usuario);
        }

        public bool Baja(string id)
        {
            return gbd.EliminarUsuario(id);
        }

        public Usuario Buscar(string id)
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
            List<Ejemplar> todosEjemplares = gbd.RecorrerEjemplares();
            List<Ejemplar> res = new List<Ejemplar>();
            foreach (Ejemplar ejemplar in todosEjemplares)
            {
                if (ejemplar.Estado == EstadoEnum.EnProceso)
                {
                    res.Add(ejemplar);
                }
            }
            return res;
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
