using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Klant
    {
        public Klant(string naam)
        {
            Naam = naam;
        }
        static int lastId = 0;
        public int KlantID { get; } = Interlocked.Increment(ref lastId);
        public string Naam { get; set; }
        public override string ToString()
        {
            return Naam;
        }
    }
}
