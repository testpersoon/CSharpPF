using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerzamelingVan = Voeding.Gerecht;


namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        public Pizza(string naam):base()
        {
            Naam = naam;
        }
        private string naamValue;
        public override string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (VerzamelingVan.allePizzas.ContainsKey(value)){
                    naamValue = value;
                    Onderdelen = VerzamelingVan.allePizzas[Naam].onderdelen;
                    Prijs = VerzamelingVan.allePizzas[Naam].prijs;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Pizzanaam: \"{value}\" bestaat niet.");
                };
            }
        }
        public override decimal Prijs { get; set; }
        private List<string> Onderdelen { get; set; }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("Pizza {0} <{1} euro> ", Naam, Prijs);
            foreach (string onderdeel in VerzamelingVan.allePizzas[Naam].onderdelen)
            {
                tekst.Append(onderdeel + " - ");
            }
            tekst.Remove(tekst.Length - 3, 3);
            return tekst.ToString(); //e.g. "Pizza Margherita <8 euro> Tomatensaus - Mozzarella"
        }
    }
}
