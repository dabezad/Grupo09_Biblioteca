using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoDato: Entity<string>
    {
        private string codigo;
        private string usuario;
        private DateTime fRealizado;
        private DateTime fFinPrestamo;
        private EstadoEnum estado;
        private string personalBAlta;
        public PrestamoDato(string codigo, string usuario, DateTime fRealizado, DateTime fFinPrestamo, EstadoEnum estado, string personal): base(codigo)
        {
            this.codigo = codigo;
            this.usuario = usuario;
            this.fRealizado = fRealizado;
            this.fFinPrestamo = fFinPrestamo;
            this.estado = estado;
            this.personalBAlta = personal;
        }
        public string Codigo { get { return this.codigo; } }
        public string Usuario { get { return this.usuario; } }
        public DateTime FRealizado { get { return this.fRealizado; } }
        public DateTime FFinPrestamo { get { return this.fFinPrestamo; } }
        public EstadoEnum Estado { get { return this.estado; } set { this.estado = value; } }
        public string PersonalBAlta { get { return this.personalBAlta; } }
    }
}
