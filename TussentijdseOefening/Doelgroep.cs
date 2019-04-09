using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public class Doelgroep
    {
        public Doelgroep(int leeftijd)
        {
            Leeftijd = leeftijd;
            if (leeftijd < 18)
            {
                Categorie = "Jeugd";
            }
            else
            {
                Categorie = "Volwassen";
            }
        }
        private int leeftijdValue;
        public int Leeftijd
        {
            get
            {
                return leeftijdValue;
            }
            set
            {
                if (value >= 0)
                {
                    leeftijdValue = value;
                }
            }
        }
        public string Categorie { get; }
        public override string ToString()
        {
            return Categorie + ", " + Leeftijd + " jaar";
        }
    }
}
