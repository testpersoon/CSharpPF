using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Klant
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        public Klant(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }

        public void Afbeelden()
        {
            Console.WriteLine("Voornaam: " + Voornaam);
            Console.WriteLine("Familienaam: " + Familienaam);
        }
    }
}
