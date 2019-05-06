using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Pizza : Gerecht
    {
        public List<string> Onderdelen { get; set; }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("Pizza {0} <{1} euro> ", Naam, Prijs);
            if (Onderdelen != null)
                foreach (string onderdeel in Onderdelen)
                    tekst.Append(onderdeel + " - ");
            tekst.Remove(tekst.Length - 3, 3);
            return tekst.ToString(); //e.g. "Pizza Margherita <8 euro> Tomatensaus - Mozzarella"
        }
    }
}
