using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Stookketel: IVervuiler
    {
        private float coNormValue;
        public float CONorm
        {
            get
            {
                return coNormValue;
            }
            set
            {
                if (value > 0)
                {
                    coNormValue = value;
                }
            }
        }
        public double GeefVervuiling()
        {
            return CONorm * 100d;
        }
        public Stookketel(float coNorm)
        {
            CONorm = coNorm;
        }
    }
}
