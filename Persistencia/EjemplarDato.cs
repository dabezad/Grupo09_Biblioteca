using ModeloDominio;
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
        private EstadoEnum estado;
        private string libro;
        private string personalBAlta;
        public EjemplarDato(string codigo, EstadoEnum estado, string libro, string personal): base(codigo)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
            this.personalBAlta = personal;
        }
        public string Codigo { get { return codigo; } }
        public EstadoEnum Estado { get { return estado; } set { this.estado = value; } }

        public string PersonalBAlta { get { return personalBAlta; } }
    }
}
