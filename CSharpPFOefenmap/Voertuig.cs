using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public abstract class Voertuig: IPrivaat, IMilieu
    {
        private decimal kostprijsValue;
        private int pkValue;
        private float gemiddeldVerbruikValue;

        public Voertuig()

            : this("onbepaald", 0m, 0, 0f, "onbepaald")
            { 
        }

        public Voertuig(string polishouder, decimal kostprijs, int pk, float gemiddeldVerbruik, string nummerplaat)
        {
            Polishouder = polishouder;
            Kostprijs = kostprijs;
            Pk = pk;
            GemiddeldVerbruik = gemiddeldVerbruik;
            Nummerplaat = nummerplaat;
        }
        /*public void Test(string tester)
        
            : this("test")
            { 
        }*/
        public string Polishouder { get; set; }
        public string Nummerplaat { get; set; }

        public decimal Kostprijs
        {
            get
            {
                return kostprijsValue;
            }
            set
            {
                if (value >= 0)
                {
                    kostprijsValue = value;
                }
            }
        }
        public int Pk
        {
            get
            {
                return pkValue;
            }
            set
            {
                if (value >= 0)
                {
                    pkValue = value;
                }
            }
        }
        public float GemiddeldVerbruik
        {
            get
            {
                return gemiddeldVerbruikValue;
            }
            set
            {
                if (value >= 0)
                {
                    gemiddeldVerbruikValue = value;
                }
            }
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine($"Polishouder: {Polishouder}");
            Console.WriteLine($"Kostprijs: {Kostprijs}");
            Console.WriteLine($"Aantal pk: {Pk}");
            Console.WriteLine($"Gemiddeld verbruik: {GemiddeldVerbruik}");
            Console.WriteLine($"Nummerplaat: {Nummerplaat}");
        }

        public string GeefMilieuData()
        {
            return ("pk: " + Pk + ", kostprijs: " + Kostprijs + ", gemiddeld verbruik: " + GemiddeldVerbruik);
        }

        public string GeefPrivateData()
        {
            return (Polishouder + " met " + Nummerplaat);
        }

        public abstract double GetKyotoScore();
    }
}
