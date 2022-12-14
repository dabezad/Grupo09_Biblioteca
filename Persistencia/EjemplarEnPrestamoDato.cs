using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class EjemplarEnPrestamoDato: Entity<ClaveEEP>
    {
        private string codPrestamo;
        private string codEjemplar;

        public EjemplarEnPrestamoDato(string codPrestamo, string codEjemplar): base(new ClaveEEP(codPrestamo, codEjemplar))
        {
            this.codPrestamo = codPrestamo;
            this.codEjemplar = codEjemplar;
        }

        public string CodPrestamo
        {
            get { return codPrestamo; }
        }
        public string CodEjemplar
        {
           get { return codEjemplar; }
        }

    }
}
