  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ModeloDominio
{
    internal class Usuario
    {
        private string dni;
        private string nombre;

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
