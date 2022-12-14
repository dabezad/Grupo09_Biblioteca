using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class ClavePMP: IEquatable<ClavePMP>
    {
        private string personalB;
        private string codPres;

        public string PersonalB
        {
            get { return personalB; }
        }
        public string CodPres
        {
            get { return codPres; }
        }
        public bool Equals(ClavePMP other)
        {
            if (other == null)
            {
                return (this.personalB == null) && (this.codPres == null);
            } else
            {
                return (this.personalB == other.PersonalB) && (this.codPres == other.CodPres);
            }
        }


    }
}
