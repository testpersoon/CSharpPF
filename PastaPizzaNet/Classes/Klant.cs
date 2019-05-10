using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Klant
    {
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public override string ToString()
        {
            return Naam;
        }
        public string StringOmWegTeSchrijven()
        {
            return KlantID + "#" + Naam;
        }
    }
}
