using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public abstract class Drank
    {
        public virtual Enums.Drank Naam { get; set; }
        public virtual decimal Prijs { get; set; }
        public abstract decimal BerekenBedrag();
        public abstract string StringOmWegTeSchrijven();
    }
}
