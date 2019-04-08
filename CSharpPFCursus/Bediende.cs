using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Bediende : Werknemer
    {
        public Bediende(string naam, DateTime inDienst, Geslacht geslacht, decimal wedde) : base(naam, inDienst, geslacht)
        {
            Wedde = wedde;
        }

        public override decimal Premie
        {
            get
            {
                return Wedde * 2m;
            }
        }

        private decimal weddeValue;
        public decimal Wedde
        {
            get
            {
                return weddeValue;
            }
            set
            {
                if (value >= 0)
                {
                    weddeValue = value;
                }
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Wedde: " + Wedde);
        }

        public override string ToString()
        {
            return base.ToString() + " " + Wedde + " euro/maand";
        }
        public override decimal Bedrag
        {
            get
            {
                return Wedde * 12m;
            }
        }
    }
}
