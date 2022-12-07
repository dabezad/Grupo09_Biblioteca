using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Ejemplar
    {
        private string codigo;
        private EstadoEnum estado;
        private Libro libro;
        private string personalBAlta;

        public Ejemplar(string codigo, EstadoEnum estado, Libro libro, string personalBAlta)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
            this.personalBAlta = personalBAlta;
        }

        public string Codigo { get { return codigo; } }
        public EstadoEnum Estado { get { return estado; } set { this.estado = value; } }
        public Libro Libro { get { return libro; } }
        
        public string PersonalBAlta { get { return personalBAlta; } }
    }
}
