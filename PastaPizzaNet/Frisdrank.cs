using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voeding;

namespace PastaPizzaNet
{
    public class Frisdrank:Drank, IBedrag
    {
        public Frisdrank(Voeding.Drank naam): base()
        {
            try
            {
                Naam = naam;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }
        private Voeding.Drank naamValue;
        public override Voeding.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (value == Voeding.Drank.CocaCola ||
                    value == Voeding.Drank.Limonade ||
                    value == Voeding.Drank.Water)
                        naamValue = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public override decimal Prijs { get; } = 2m;
        public override decimal BerekenBedrag()
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
