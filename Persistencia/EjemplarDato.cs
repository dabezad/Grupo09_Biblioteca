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
        private EstadoEjemplarEnum estado;
        private string libro;
        private string personalBAlta;
        public EjemplarDato(string codigo, EstadoEjemplarEnum estado, string libro, string personal): base(codigo)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.libro = libro;
            this.personalBAlta = personal;
        }
        public string Codigo { get { return codigo; } }
        public EstadoEjemplarEnum Estado { get { return estado; } set { this.estado = value; } }
        public string Libro { get { return libro; } }

        public string PersonalBAlta { get { return personalBAlta; } }
    }
}
