using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Prestamo
    {
        private string codigo;
        private Usuario usuario;
        private Ejemplar[] ejemplares;
        private DateTime fRealizado;
        private DateTime fFinPrestamo;
        private EstadoEnum estado;
        private string personalBAlta;

        public Prestamo(string codigo, Usuario usuario, Ejemplar[] ejemplares, DateTime fRealizado, DateTime fFinPrestamo, string personalBAlta)
        {
            this.codigo = codigo;
            this.usuario = usuario;
            this.ejemplares = ejemplares;
            this.fRealizado = fRealizado;
            this.fFinPrestamo = fFinPrestamo;
            this.estado = EstadoEnum.EnProceso;
            this.personalBAlta = personalBAlta;
        }

        public string Codigo { get { return this.codigo; } }
        public Usuario Usuario { get { return this.usuario; } }
        public Ejemplar[] Ejemplares { get { return this.ejemplares; } set { this.ejemplares = value; } } 
        public DateTime FRealizado { get { return this.fRealizado; } }
        public DateTime FFinPrestamo { get { return this.fFinPrestamo; } set { this.fFinPrestamo = value; } }
        public EstadoEnum Estado { get { return this.estado; } set { this.estado = value; } }
        public string PersonalBAlta { get { return this.personalBAlta; } }
    }
}
