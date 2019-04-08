using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma;
using Firma.Personeel;
using Firma.Materiaal;
using MateriaalStatus = Firma.Materiaal.Status;
using PersoneelStatus = Firma.Personeel.Status;


namespace CSharpPFCursus
{
    public enum Seizoen
    {
        Lente, Zomer, Herfst, Winter
    }

    class Program
    {
        static void Main(string[] args)
        {
            var statusBoorMachine = MateriaalStatus.Werkend;
            var statusChef = PersoneelStatus.HogerKader;
            Console.WriteLine(statusBoorMachine);
            Console.WriteLine(statusChef);
        }

        public static (int aantalVerlofdagen, int aantalZiektedagen) Afwezigheden(Werknemer werknemer)
        {
            (int, int) aantalAfwezigheden = (werknemer.Verlofdagen.Length, werknemer.Ziektedagen.Length);
            return aantalAfwezigheden;
        }
    }
}
