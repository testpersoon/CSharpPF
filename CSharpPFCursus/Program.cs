using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Werknemer asterix = new Arbeider("Asterix", new DateTime(2018, 1, 1), Geslacht.Man, 24.79m, 3);
            asterix.Verlofdagen = new DateTime[] { new DateTime(2018, 2, 1), new DateTime(2018, 2, 2), new DateTime(2018, 5, 11) };
            asterix.Ziektedagen = new DateTime[] { new DateTime(2018, 6, 4), new DateTime(2018, 6, 5), new DateTime(2018, 6, 6), new DateTime(2018, 6, 7), new DateTime(2018, 6, 8) };
            Werknemer obelix = new Bediende("Obelix", new DateTime(1995, 2, 1),
            Geslacht.Man, 2400.79m);
            obelix.Verlofdagen = new DateTime[] { new DateTime(2018, 7, 9), new DateTime(2018, 7, 10), new DateTime(2018, 7, 11), new DateTime(2018, 7, 12), new DateTime(2018, 7, 13) };
            obelix.Ziektedagen = new DateTime[] { new DateTime(2018, 8, 1), new DateTime(2018, 8, 2), new DateTime(2018, 8, 3) };
            (int aantalVerlofdagen, int aantalZiektedagen) afwezighedenAsterix =
            Afwezigheden(asterix);
            Console.WriteLine($"Asterix: " + $"{afwezighedenAsterix.aantalVerlofdagen} verlofdagen + "
                + $"{afwezighedenAsterix.aantalZiektedagen} ziektedagen");
            var afwezighedenObelix = Afwezigheden(obelix);
            Console.WriteLine($"Obelix: " + $"{afwezighedenObelix.aantalVerlofdagen} verlofdagen +" + $" {afwezighedenObelix.aantalZiektedagen} ziektedagen");
        }

        public static (int aantalVerlofdagen, int aantalZiektedagen) Afwezigheden(Werknemer werknemer)
        {
            (int, int) aantalAfwezigheden = (werknemer.Verlofdagen.Length, werknemer.Ziektedagen.Length);
            return aantalAfwezigheden;
        }
    }
}
