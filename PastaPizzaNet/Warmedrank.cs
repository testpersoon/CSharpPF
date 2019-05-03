using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Warmedrank: Drank, IBedrag
    {
        public Warmedrank(Voeding.Drank naam) : base()
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
                if (value == Voeding.Drank.Koffie ||
                    value == Voeding.Drank.Thee)
                    naamValue = value;
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public override decimal Prijs { get; } = 2.5m;
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
