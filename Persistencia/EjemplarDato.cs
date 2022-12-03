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
        private string libro;
        private string personalBAlta;
        public EjemplarDato(string codigo, string estado, string libro, string personal): base(codigo)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
            this.personalBAlta = personal;
        }
        public string Codigo { get { return codigo; } }
        public string Estado { get { return estado; } set { this.estado = value; } }
    }
}
