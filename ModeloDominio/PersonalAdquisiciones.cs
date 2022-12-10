using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisiciones : PersonalBiblioteca
    {
        public PersonalAdquisiciones(string nombre, string contraseña) : base(nombre, contraseña) { }
    }
}
