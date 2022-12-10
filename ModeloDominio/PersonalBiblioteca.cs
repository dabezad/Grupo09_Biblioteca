using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalBiblioteca
    {
        private string nombre;
        private string contraseña;

        public PersonalBiblioteca(string nombre, string contraseña)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

        public string Nombre { get { return nombre; } }
        public string Contraseña { get { return contraseña; } }
    }

}
