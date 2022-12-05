  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ModeloDominio
{
    public class Usuario
    {
        private string dni;
        private string nombre;
        private string personalBAlta;

        public Usuario(string dni, string nombre, string personal)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.personalBAlta = personal;
        }

        public string Dni
        {
            get { return this.dni; }
        }

        public string Nombre
        { 
            get {  return this.nombre; } 
            set {  this.nombre = value; }
        }

        public string PersonalBAlta
        {
            get
            {  return this.personalBAlta; }
        }

    }
}
