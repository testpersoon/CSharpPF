using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class BankBediende
    {
        public BankBediende(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public override string ToString()
        {
            return $"Bankbediende: {Voornaam} {Familienaam}";
        }

        public void RekeningUittrekselTonen(Rekening rekening)
        {
            Console.WriteLine($"Datum: {DateTime.Today:dd-MM-yyyy}");
            Console.WriteLine($"Rekeninguittreksel van " +
            $"rekening {rekening.Rekeningnummer}");
            Console.WriteLine($"Vorig saldo: {rekening.VorigSaldo} euro");
            if (rekening.Saldo > rekening.VorigSaldo)
            {
                Console.WriteLine($"Storting van " +
                $"{rekening.Saldo - rekening.VorigSaldo} euro.");
            }
            else
            {
                Console.WriteLine($"Afhaling van " +
                $"{rekening.VorigSaldo - rekening.Saldo} euro.");
            }
            Console.WriteLine($"Nieuw saldo: {rekening.Saldo} euro");
        }
        public void BoodschapSaldoOntoereikend(Rekening rekening)
        {
            Console.WriteLine("Afhaling niet mogelijk, saldo ontoereikend!");
            Console.WriteLine($"Maximum af te halen bedrag: " +
            $"{rekening.Saldo} euro");
        }
    }
}
