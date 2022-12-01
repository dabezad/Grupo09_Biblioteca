using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class EjemplarDato: Entity<string>
    {
        private string codigo;
        private string estado;
        private LibroDato libro;
        public EjemplarDato(string codigo, string estado, LibroDato libro): base(codigo)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
        }
        public string Codigo { get { return codigo; } }
        public string Estado { get { return estado; } set { this.estado = value; } }
    }
}
