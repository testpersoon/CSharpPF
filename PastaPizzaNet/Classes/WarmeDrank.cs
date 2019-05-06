using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class WarmeDrank: Drank, IBedrag
    {
        private static readonly List<Enums.Drank> warmeDranken = new List<Enums.Drank> { Enums.Drank.Koffie, Enums.Drank.Thee};
        private Enums.Drank naamValue;
        public override Enums.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (string.Join(",", warmeDranken).Contains(value.ToString()))
                    naamValue = value;
                else
                    throw new GeenWarmeDrankException("Deze drank is geen warme drank", value.ToString());
            }
        }
        public override decimal Prijs
        {
            get
            {
                return 2.5m;
            }
        }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1:0.0} euro>", Naam.ToString(), Prijs);
            return tekst.ToString();
        }
    }
}
