﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoDato: Entity<string>
    {
        private string codigo;
        private UsuarioDato usuario;
        private EjemplarDato[] ejemplares;
        private DateTime fRealizado;
        private DateTime fFinPrestamo;
        private string estado;
        public PrestamoDato(string codigo, UsuarioDato usuario, EjemplarDato[] ejemplares, DateTime fRealizado, DateTime fFinPrestamo, string estado): base(codigo)
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
