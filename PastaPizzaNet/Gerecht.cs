﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Gerecht: IBedrag
    {
        public abstract string Naam { get; set; }
        public abstract decimal Prijs { get; set; }
        public abstract decimal BerekenBedrag();
    }
}
