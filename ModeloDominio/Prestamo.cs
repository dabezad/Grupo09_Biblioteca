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
        private string estado;

        private Prestamo(string codigo, Usuario usuario, Ejemplar[] ejemplares, DateTime fRealizado, DateTime fFinPrestamo, string estado)
        {
            this.codigo = codigo;
            this.usuario = usuario;
            this.ejemplares = ejemplares;
            this.fRealizado = fRealizado;
            this.fFinPrestamo = fFinPrestamo;
            this.estado = estado;
        }

        public string Codigo { get { return this.codigo; } }
        public DateTime FRealizado { get { return this.fRealizado; } }
        public DateTime FFinPrestamo { get { return this.fFinPrestamo; } }
        public string Estado { get { return this.estado; } set { this.estado = value; } }
    }
}
