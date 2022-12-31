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
        private List<Ejemplar> ejemplares;
        private DateTime fRealizado;
        private DateTime fFinPrestamo;
        private EstadoEnum estado;
        private PersonalSala personalBAlta;

        public Prestamo(string codigo, Usuario usuario, List<Ejemplar> ejemplares, DateTime fRealizado, DateTime fFinPrestamo, PersonalSala personalBAlta)
        {
            this.codigo = codigo;
            this.usuario = usuario;
            this.ejemplares = ejemplares;
            this.fRealizado = fRealizado;
            this.fFinPrestamo = fFinPrestamo;
            this.estado = EstadoEnum.EnProceso;
            this.personalBAlta = personalBAlta;
        }

        public Prestamo(string codigo, Usuario usuario, List<Ejemplar> lejemplares, DateTime fRealizado, DateTime fFin, EstadoEnum estadoP, PersonalSala personalBAlta)
        {
            this.codigo = codigo;
            this.usuario = usuario;
            this.ejemplares = lejemplares;
            this.fRealizado = fRealizado;
            this.fFinPrestamo = fFin;
            this.estado = estadoP;
            this.personalBAlta = personalBAlta;
        }

        public string Codigo { get { return this.codigo; } }
        public Usuario Usuario { get { return this.usuario; } }
        public List<Ejemplar> Ejemplares { get { return this.ejemplares; } set { this.ejemplares = value; } } 
        public DateTime FRealizado { get { return this.fRealizado; } }
        public DateTime FFinPrestamo { get { return this.fFinPrestamo; } set { this.fFinPrestamo = value; } }
        public EstadoEnum Estado { get { return this.estado; } set { this.estado = value; } }
        public PersonalSala PersonalBAlta { get { return this.personalBAlta; } }
    }
}
