using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Afdeling
    {
        public const int Verdiepingen = 10;
        private int verdiepingValue;
        public string Naam { get; set; }
        public int Verdieping
        {
            get
            {
                return verdiepingValue;
            }
            set
            {
                if (value >= 0 && value <= Verdiepingen)
                    verdiepingValue = value;
            }
        }

        public override string ToString()
        {
            return String.Format($"Afdeling: {Naam} op verdieping {Verdieping}");
        }

        public Afdeling(string naam, int verdieping)
        {
            Naam = naam;
            Verdieping = verdieping;
        }
    }
}
