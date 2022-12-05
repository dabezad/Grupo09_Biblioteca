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

        public Usuario(string dni, string nombre)
        {
            this.dni = dni;
            Nombre = nombre;
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

    }
}
