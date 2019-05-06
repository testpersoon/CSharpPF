using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Dessert:IBedrag
    {
        public Enums.Dessert Naam { get; set; }
        public decimal Prijs
        {
            get
            {
                switch (Naam)
                {
                    case Enums.Dessert.Tiramisu:
                    case Enums.Dessert.Ijs:
                        return 3m;
                    case Enums.Dessert.Cake:
                        return 2m;
                    default:
                        throw new PrijsVanDessertNietGevonden("Geen prijs gevonden voor dit dessert: ", Naam.ToString());
                }
            }
        }
        public decimal BerekenBedrag()
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
