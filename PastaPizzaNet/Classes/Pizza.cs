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
                tekst.AppendFormat(string.Join(" - ", Onderdelen));
            return tekst.ToString(); //e.g. "Pizza Margherita <8 euro> Tomatensaus - Mozzarella"
        }
        public override string StringOmWegTeSchrijven()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0}#{1}#{2}#{3}",
                Enums.TypeGerecht.pizza,
                Naam,
                Prijs,
                string.Join("#", Onderdelen));
            
            return tekst.ToString(); //e.g. "pizza#Pizza Margherita#8#Tomatensaus#Mozzarella
        }
    }
}
