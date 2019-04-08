using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Spaarrekening : Rekening
    {
        private static decimal intrestValue;
        public static decimal Intrest
        {
            get
            {
                return intrestValue;
            }
            set
            {
                if (value >= 0m)
                {
                    intrestValue = value;
                }
            }
        }

        public Spaarrekening (string nummer, decimal saldo, DateTime creatieDatum, Klant eigenaar): base(nummer, saldo, creatieDatum, eigenaar)
        {
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Intrest: " + Intrest);
        }
    }
}
