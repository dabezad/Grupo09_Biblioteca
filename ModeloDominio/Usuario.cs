using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ModeloDominio
{
    public class Usuario: IEquatable<Usuario>
    {
        private string dni;
        private string nombre;
        private PersonalBiblioteca personalBAlta;

        public Usuario(string dni, string nombre, PersonalBiblioteca personal)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.personalBAlta = personal;
        }

        public Usuario(string dni, string nombre)
        {
            this.dni = dni;
            this.nombre = nombre;
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

        public PersonalBiblioteca PersonalBAlta
        {
            get
            {  return this.personalBAlta; }
        }

        public  bool Equals(Usuario otro)
        {
            if (otro == null)
            {
                return this == null;
            } else
            {
                return otro.Dni == this.Dni;
            }
        }
    }
}
