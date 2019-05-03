using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerzamelingVan = Voeding.Gerecht;

namespace PastaPizzaNet
{
    public class Pasta: Gerecht
    {
        public Pasta(string naam) : base()
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
                if (VerzamelingVan.allePastas.ContainsKey(value))
                {
                    naamValue = value;
                    this.Omschrijving = VerzamelingVan.allePastas[this.Naam].omschrijving;
                    this.Prijs = VerzamelingVan.allePastas[this.Naam].prijs;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Pastanaam: \"{value}\" bestaat niet.");
                };
            }
        }
        public override decimal Prijs { get; set; }
        private string Omschrijving { get; set; }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1} euro> {2}", Naam, Prijs, VerzamelingVan.allePastas[Naam].omschrijving);
            return tekst.ToString(); //e.g. "Spaghetti Bolognese <12 euro> met gehaktsaus"
        }
    }
}
