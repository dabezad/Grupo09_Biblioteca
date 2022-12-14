using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class ClaveEEP: IEquatable<ClaveEEP> 
    {
        private string codPres;
        private string codEjem;
        public string CodPres
        {
            get { return codPres; }
        }
        public string CodEjem
        {
            get { return codEjem; }
        }

        public bool Equals(ClaveEEP other)
        {
            if (other == null)
            {
                return (this.codPres == null) && (this.codEjem == null);
            } else
            {
                return (this.codPres == other.CodPres) && (this.codEjem == other.CodEjem);
            }
        }
    }
}
