using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalBibliotecaDato : Entity<string>
    {
        private string nombre;
        private string contraseña;

        public PersonalBibliotecaDato(string nombre, string contraseña) : base(nombre)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

        public string Nombre { get { return nombre; } }
        public string Contraseña { get { return contraseña; } }
    }
}
