using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Drank
    {
        public abstract Voeding.Drank Naam { get; set; }
        public abstract decimal Prijs { get;}
        public abstract decimal BerekenBedrag();
    }
}
