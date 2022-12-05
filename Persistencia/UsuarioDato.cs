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
        private string personalBAlta;
        public UsuarioDato(string dni, string nombre, string personal): base(dni)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.personalBAlta = personal;
        }
        public string Dni { get { return dni; } }
        public string Nombre { get { return nombre; } }
        public string PersonalBAlta { get { return this.personalBAlta; } }
    }
}
