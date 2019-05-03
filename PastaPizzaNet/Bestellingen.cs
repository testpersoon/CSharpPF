using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PastaPizzaNet
{
    public static class Bestellingen
    {
        static readonly string divider = "*************************************************************************************";
        private static List<Bestelling> alleBestellingenValue;
        public static ReadOnlyCollection<Bestelling> AlleBestellingen()
        {
            return new ReadOnlyCollection<Bestelling>(alleBestellingenValue);
        }
        public static void BestellingPlaatsen(Klant klant = null, BesteldGerecht gerecht = null, Drank drank = null, Dessert dessert = null, int aantal = 1)
        {
            var bestelling = new Bestelling { BesteldGerecht = gerecht, Drank = drank, Dessert = dessert, Klant = klant, Aantal = aantal };
            if (alleBestellingenValue == null)
                alleBestellingenValue = new List<Bestelling>();
            alleBestellingenValue.Add(bestelling);
        }
        public static void Tonen()
        {
            if (alleBestellingenValue != null){
                foreach (var bestelling in AlleBestellingen()
                    .OrderBy(x => x.BestellingID))
                {
                    Console.WriteLine(bestelling.ToString() + "\n");
                    Console.WriteLine(divider);
                }
            }
            else
            {
                Console.WriteLine("\nEr zijn nog geen bestellingen geplaatst.\n");
                Console.WriteLine(divider);
            }
        }
        public static void TonenVanKlant(Klant klant)
        {
            if (alleBestellingenValue == null)
            {
                Console.WriteLine("\nEr zijn nog geen bestellingen geplaatst.");
            }
            else if (klant == null)
            {
                Console.WriteLine("\nOnbekende klanten:");
                BestellingenAfprintenVan(klant);
            }
            else if (AlleBestellingen()
                .Where(x => x.Klant == klant).Count() == 0)
            {
                Console.WriteLine(string.Format("Bestellingen van klant {0}:\n", klant.ToString()));
                Console.WriteLine("Deze klant heeft nog geen bestellingen geplaatst.");
            }
            else
            {
                Console.WriteLine(string.Format("Bestellingen van klant {0}:\n", klant.ToString()));
                BestellingenAfprintenVan(klant);
            }
            Console.WriteLine();
            Console.WriteLine(divider);
        }
        private static void BestellingenAfprintenVan(Klant klant)
        {
            decimal totaalBedrag = 0;
            var bestellingenKlant = AlleBestellingen()
                .Where(x => x.Klant == klant)
                .OrderBy(x => x.BestellingID);
            foreach (var bestelling in bestellingenKlant)
            {
                Console.WriteLine(bestelling.ToString());
                Console.WriteLine();
                totaalBedrag += bestelling.BerekenBedrag();
            }
            if (klant != null)
            {
                Console.WriteLine(string.Format("Het totaal bedrag van alle bestellingen van klant {0}: {1} euro", klant.ToString(), totaalBedrag));
            }
        }
        public static void TonenPerKlant()
        {
            var bestellingenPerKlant = AlleBestellingen()
                                    .GroupBy(x => x.Klant)
                                    .OrderBy(x => x?.Key?.KlantID?? Int32.MaxValue);
            foreach (var klant in bestellingenPerKlant)
            {
                Bestellingen.TonenVanKlant(klant.Key);
            }
        }
    }
}
