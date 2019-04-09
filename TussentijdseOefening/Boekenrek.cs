using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public class Boekenrek: IVoorwerpen
    {
        public Boekenrek(double hoogteCentimeter, double breedteCentimeter, decimal aankoopprijs)
        {
            Hoogte = hoogteCentimeter;
            Breedte = breedteCentimeter;
            Aankoopprijs = aankoopprijs;
        }
        private double hoogteValue;
        public double Hoogte
        {
            get
            {
                return hoogteValue;
            }
            set
            {
                if (value > 0)
                {
                    hoogteValue = value;
                }
            }
        }
        private double breedteValue;
        public double Breedte
        {
            get
            {
                return breedteValue;
            }
            set
            {
                if (value > 0)
                {
                    breedteValue = value;
                }
            }
        }
        private decimal aankoopprijsValue;
        public decimal Aankoopprijs
        {
            get
            {
                return aankoopprijsValue;
            }
            set
            {
                if (value > 0)
                {
                    aankoopprijsValue = value;
                }
            }
        }
        public decimal Winst
        {
            get
            {
                return Aankoopprijs * 2m;
            }
        }

        public void GegevensTonen()
        {
            Console.WriteLine();
            Console.WriteLine("---Gegevens boekenrek---");
            Console.WriteLine($"Hoogte: {Hoogte}cm");
            Console.WriteLine($"Breedte: {Breedte}cm");
            Console.WriteLine($"Aankoopprijs: {Math.Round(Aankoopprijs,2)} euro");
            Console.WriteLine($"Winst: {Math.Round(Winst,2)} euro");
        }
    }
}
