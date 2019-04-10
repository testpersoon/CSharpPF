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
            var jefke = new Klant("Jeff", "Bezos");
            var meneerDeBankbediende = new BankBediende("Alberto", "Vermicelli");
            var zichtrekening = new Zichtrekening("BE11 4050 5046 1148", 450m, DateTime.Now, -200m, jefke);
            var spaarrekening = new Spaarrekening("test", 12m, DateTime.Now, jefke);
            zichtrekening.RekeningUittreksel += meneerDeBankbediende.RekeningUittrekselTonen;
            zichtrekening.SaldoInHetRood += meneerDeBankbediende.BoodschapSaldoOntoereikend;
            zichtrekening.Storten(400m);
            spaarrekening.RekeningUittreksel += meneerDeBankbediende.RekeningUittrekselTonen;
            spaarrekening.SaldoInHetRood += meneerDeBankbediende.BoodschapSaldoOntoereikend;
            spaarrekening.Afhalen(40m);
        }
    }
}
