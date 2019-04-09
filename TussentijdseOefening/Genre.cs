using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public class Genre
    {
        public Genre(string naam, Doelgroep doelgroep)
        {
            Naam = naam;
            Doelgroep = doelgroep;
        }
        public string Naam { get; set; }
        public Doelgroep Doelgroep { get; set; }
        public override string ToString()
        {
            return Naam + ", " + Doelgroep;
        }
    }
}
