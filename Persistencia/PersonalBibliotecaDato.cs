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
        private string tipo;

        public PersonalBibliotecaDato(string nombre, string contraseña, string tipo) : base(nombre)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.tipo = tipo;    
        }

        public string Nombre { get { return nombre; } }
        public string Contraseña { get { return contraseña; } }

        public string Tipo { get { return tipo; } }
    }
}
