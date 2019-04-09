using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    class Program
    {
        static void Main(string[] args)
        {
            Doelgroep jeugd = new Doelgroep(15);
            Genre avontuur = new Genre("Avontuur", jeugd);
            var leesboek = new Leesboek("Blinker en de bakfietsbioscoop", "Marc de Bel", 5.99m, avontuur, "Blinker gaat op pad en vindt zijn vrienden");
            Doelgroep volwassen = new Doelgroep(40);
            Genre educatief = new Genre("Educatief", volwassen);
            var woordenboek = new Woordenboek("Nederlands", "Van Dale", 39.99m,educatief, "Nederlands");
            var boekenrek = new Boekenrek(210, 350, 79.99m);
            IVoorwerpen[] voorwerpen = new IVoorwerpen[3];
            voorwerpen[0] = leesboek;
            voorwerpen[1] = woordenboek;
            voorwerpen[2] = boekenrek;
            foreach (IVoorwerpen item in voorwerpen)
            {
                item.GegevensTonen();
            }
        }
    }
}
