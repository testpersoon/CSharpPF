using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voeding;

namespace PastaPizzaNet
{
    public class Dessert:IBedrag
    {
        public Dessert(Voeding.Dessert naam)
        {
            Naam = naam;
        }
        private Voeding.Dessert naamValue;
        public Voeding.Dessert Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                naamValue = value;
                PrijsInvullen();
            }
        }
        public decimal Prijs { get; set; }
        private void PrijsInvullen()
        {
            switch (Naam){
                case Voeding.Dessert.Tiramisu:
                    Prijs = 3m;
                    break;
                case Voeding.Dessert.Ijs:
                    Prijs = 3m;
                    break;
                case Voeding.Dessert.Cake:
                    Prijs = 2m;
                    break;
            }
        }
        public decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1} euro>", Naam.ToString(), Prijs);
            return tekst.ToString();
        }
    }
}
