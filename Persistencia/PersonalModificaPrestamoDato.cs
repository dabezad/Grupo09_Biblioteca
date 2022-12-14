using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalModificaPrestamoDato: Entity<ClavePMP>
    {
        private string personalB;
        private string codPrestamo;

        public PersonalModificaPrestamoDato(string personalB, string codPrestamo): base(new ClavePMP(personalB, codPrestamo))
        {
            this.personalB = personalB;
            this.codPrestamo = codPrestamo;
        }
        public string PersonalB
        {
            get { return personalB; }
        }
        public string CodPrestamo
        {
            get { return codPrestamo; }
        }
    }
}
