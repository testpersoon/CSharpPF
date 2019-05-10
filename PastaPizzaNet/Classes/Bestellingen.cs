using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PastaPizzaNet.Classes
{
    public static class Bestellingen
    {
        static readonly string divider = "*************************************************************************************";
        private static List<Bestelling> alleBestellingenValue;
        public static ReadOnlyCollection<Bestelling> AlleBestellingen()
        {
            return new ReadOnlyCollection<Bestelling>(alleBestellingenValue??new List<Bestelling>());
        }
        public static void Toevoegen(Bestelling bestelling)
        {
            if (alleBestellingenValue == null)
                alleBestellingenValue = new List<Bestelling>();
            alleBestellingenValue.Add(bestelling);
        }
        public static string Tonen()
        {
            StringBuilder tekst = new StringBuilder();
            if (AlleBestellingen().Count > 0){
                int i = 1;
                foreach (var bestelling in AlleBestellingen())
                    tekst.AppendFormat("Bestelling {0}:\n{1}\n\n{2}\n", i++, bestelling.ToString(), divider);
            }
            else
            {
                tekst.AppendFormat("\nEr zijn nog geen bestellingen geplaatst.\n\n{0}", divider);
            }
            return tekst.ToString();
        }
        public static string TonenVanKlant(Klant klant)
        {
            StringBuilder tekst = new StringBuilder();
            if (AlleBestellingen().Count != 0)
            {
               
                if (klant == null)
                {
                    tekst.AppendFormat("\nOnbekende klanten:\n\n");
                    tekst.AppendFormat(BestellingenVan(klant));
                }
                else if (AlleBestellingen()
                    .Where(x => (x?.Klant?.KlantID??0) == klant.KlantID).Count() == 0)
                {
                    tekst.AppendFormat("\nBestellingen van klant {0}:\n\n", klant.ToString());
                    tekst.AppendFormat("Deze klant heeft nog geen bestellingen geplaatst.\n");
                }
                else
                {
                    tekst.AppendFormat("\nBestellingen van klant {0}:\n\n", klant.ToString());
                    tekst.AppendFormat(BestellingenVan(klant));
                }
            }
            else
            {
                tekst.AppendFormat("\nEr zijn nog geen bestellingen geplaatst.\n");
            }
            tekst.AppendFormat("\n{0}\n", divider);
            return tekst.ToString();
        }
        private static string BestellingenVan(Klant klant)
        {
            StringBuilder tekst = new StringBuilder();
            decimal totaalBedrag = 0;
            var bestellingenKlant = AlleBestellingen()
                .Where(x => (x?.Klant?.KlantID ?? 0) == (klant?.KlantID ?? 0));
            foreach (var bestelling in bestellingenKlant)
            {
                tekst.AppendFormat("{0}\n\n", bestelling.ToString());
                totaalBedrag += bestelling.BerekenBedrag();
            }
            if (klant != null)
                tekst.AppendFormat("Het totaal bedrag van alle bestellingen van klant {0}: {1} euro\n", klant.ToString(), totaalBedrag);
            return tekst.ToString();
        }
        public static string TonenPerKlant()
        {
            StringBuilder tekst = new StringBuilder();
            if (AlleBestellingen().Count > 0)
            {
                var bestellingenPerKlant = AlleBestellingen()
                                            .GroupBy(x => x.Klant)
                                            .OrderBy(x => x?.Key?.KlantID ?? int.MaxValue);
                foreach (var klant in bestellingenPerKlant)
                {
                    tekst.AppendFormat(TonenVanKlant(klant.Key));
                }
            }
            else
            {
                tekst.Append("\nEr zijn nog geen bestellingen geplaatst.\n");
            }
            return tekst.ToString();
        }
    }
}
