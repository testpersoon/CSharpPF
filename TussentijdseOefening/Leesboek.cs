using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public class Leesboek: Boek
    {
        public Leesboek(string titel, string auteur, decimal aankoopprijs, Genre genre, string onderwerp): base(titel, auteur, aankoopprijs, genre)
        {
            Onderwerp = onderwerp;
        }
        public string Onderwerp { get; set; }
        public override decimal Winst
        {
            get { return Aankoopprijs * 1.5m; }
        }
        public override void GegevensTonen()
        {
            Console.WriteLine();
            Console.WriteLine("---Leesboek---");
            base.GegevensTonen();
            Console.WriteLine($"Onderwerp: {Onderwerp}");
            Console.WriteLine($"Winst: {Math.Round(Winst,2)} euro");
        }
    }
}
