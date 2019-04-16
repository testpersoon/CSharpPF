using System;
using System.Collections;
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
        public static void Main(string[] args)
        {
            var brouwers = new Brouwers().GetBrouwers();
            var opBelgisch = from brouwer in brouwers
                             from bier in brouwer.Bieren
                             group bier by brouwer.Belgisch
            into bieren
                             select new
                             {
                                 Bieren = bieren,
                                 Belgisch = bieren.Key,
                                 AantalBieren = bieren.Count()
                             };
            foreach (var groep in opBelgisch)
            {
                Console.WriteLine((groep.Belgisch ? "Belgische bieren: " :
                "Niet-Belgische bieren: ") + groep.AantalBieren);
                foreach (var bier in groep.Bieren)
                    Console.WriteLine(bier.Biernaam);
            }
        }
    }
}
