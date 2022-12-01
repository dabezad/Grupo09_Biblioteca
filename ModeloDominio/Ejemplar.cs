using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    internal class Ejemplar
    {
        private string codigo;
        private string estado;
        private Libro libro;

        private Ejemplar(string codigo, string estado, Libro libro)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
        }

        public string Codigo { get { return codigo; } }
        public string Estado { get { return estado; } set { this.estado = value; } }
    }
}
