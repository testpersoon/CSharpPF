using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public sealed class Manager : Bediende
    {
        public Manager(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde, decimal bonus) : base(naam, inDienst, geslacht, wedde)
        {
            Bonus = bonus;
        }

        public override decimal Premie
        {
            get
            {
                return Bonus * 3m;
            }
        }

        private decimal bonusValue;
        public decimal Bonus
        {
            get
            {
                return bonusValue;
            }
            set
            {
                if (value >= 0)
                {
                    bonusValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Bonus: " + Bonus);
        }

        public override string ToString()
        {
            return base.ToString() + ", Bonus:" + Bonus;
        }

        public override decimal Bedrag
        {
            get
            {
                return base.Bedrag + Bonus;
            }
        }
    }
}
