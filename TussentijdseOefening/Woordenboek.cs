using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public class Woordenboek: Boek
    {
        public Woordenboek(string titel, string auteur, decimal aankoopprijs, Genre genre, string taal) : base(titel, auteur, aankoopprijs, genre)
        {
            Taal = taal;
        }
        public string Taal { get; set; }
        public override decimal Winst
        {
            get { return Aankoopprijs * 1.75m; }
        }
        public override void GegevensTonen()
        {
            Console.WriteLine();
            Console.WriteLine("---Woordenboek---");
            base.GegevensTonen();
            Console.WriteLine($"Taal: {Taal}");
            Console.WriteLine($"Winst: {Math.Round(Winst,2)} euro");
        }
    }
}
