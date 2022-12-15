using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    //gadeamm
    public class LNBiblioteca
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

        public bool Baja(Usuario usuario)
        {
            return gbd.CrearUsuario(usuario);
        }

        public bool 

    }
}
