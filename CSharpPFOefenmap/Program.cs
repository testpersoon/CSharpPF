using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var jefke = new Klant("Jeff", "Bezos");
                var meneerDeBankbediende = new BankBediende("Alberto", "Vermicelli");
                var zichtrekening = new Zichtrekening("BE11 4050 5046 1148", 450m, new DateTime(1999,2,2), -200m, jefke);
                var spaarrekening = new Spaarrekening("BE11 4050 5046 1148", 12m, DateTime.Now, jefke);
                Spaarrekening.Intrest = 5m;
                var kasbon = new Kasbon(new DateTime(2010, 9, 9), 50m, 5, 10, jefke);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout: {ex.Message}");
            }
        }
    }
}
