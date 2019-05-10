using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Pasta: Gerecht
    {
        public string Omschrijving { get; set; }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1} euro> {2}", Naam, Prijs, Omschrijving);
            return tekst.ToString(); //e.g. "Spaghetti Bolognese <12 euro> met gehaktsaus"
        }
        public override string StringOmWegTeSchrijven()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("pasta#{0}#{1}#{2}",
                Naam,
                Prijs,
                Omschrijving);
            return tekst.ToString(); //e.g. "pasta#Spaghetti Bolognese#12#met gehaktsaus"
        }
    }
}
