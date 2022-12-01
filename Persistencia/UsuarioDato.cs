using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato: Entity<string>
    {
        private string dni;
        private string nombre;
        public UsuarioDato(string dni, string nombre): base(dni)
        {
            this.dni = dni;
            this.nombre = nombre;
        }
    }
}
