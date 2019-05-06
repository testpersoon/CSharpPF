using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Frisdrank:Drank, IBedrag
    {
        private static readonly List<Enums.Drank> frisdranken = new List<Enums.Drank> { Enums.Drank.CocaCola, Enums.Drank.Limonade, Enums.Drank.Water };

        private Enums.Drank naamValue;
        public override Enums.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (string.Join(",", frisdranken).Contains(value.ToString()))
                    naamValue = value;
                else
                    throw new GeenFrisdrankException("Dit is geen frisdrank: ", value.ToString());
            }
        }
        public override decimal Prijs
        {
            get
            {
                return 2m;
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
