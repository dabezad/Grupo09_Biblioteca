using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class EjemplarEnPrestamo: IEquatable<EjemplarEnPrestamo>
    {
        string codPr;
        string codEj;

        public EjemplarEnPrestamo(string codP, string codEj)
        {
            this.codPr = codP;
            this.codEj = codEj;
        }

        public string CodPr
        {
            get { return codPr; }
        }

        public string CodEj
        {
            get { return codEj; }
        }

        public bool Equals(EjemplarEnPrestamo otro)
        {
            if (otro == null)
            {
                return this == null;
            } else
            {
                return (otro.CodPr == codPr && otro.CodEj == codEj);
            }
            
        }
    }
}
