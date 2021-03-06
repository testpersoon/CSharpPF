﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class BesteldGerecht:IBedrag
    {
        static readonly decimal supplementGroot = 3m, supplementExtra = 1m;
        public Gerecht Gerecht { get; set; }
        public Enums.Grootte Grootte { get; set; }
        public List<Enums.Extra> Extras { get; set; }
        public decimal BerekenBedrag()
        {
            decimal bedrag = 0;
            bedrag += (Gerecht?.BerekenBedrag() ?? 0m);
            bedrag += (Grootte == Enums.Grootte.Groot ? supplementGroot : 0m);
            bedrag += ((Extras?.Count ?? 0m) * supplementExtra);
            return bedrag;
        }
        public override string ToString()
        {
            string extras = Extras?.Count > 0? " extra: " : "";
            extras += string.Join(" ", Extras ?? new List<Enums.Extra>());
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0} <{1}>{2} <bedrag: {3} euro>", Gerecht.ToString(), Grootte, extras, BerekenBedrag());
                            //e.g. "Spaghetti Bolognese <12 euro> met gehaktsaus <Groot> extra: Kaas <bedrag: 16 euro>"
            return tekst.ToString();
        }
        public string StringOmWegTeSchrijven()
        {
            StringBuilder tekst = new StringBuilder();
            tekst.AppendFormat("{0}-{1}-{2}-{3}",
                Gerecht.Naam,
                Grootte,
                Extras?.Count??0,
                string.Join("-", Extras ?? new List<Enums.Extra>()));
            //e.g. "Spaghetti Bolognese-Groot-1-Kaas"
            return tekst.ToString();
        }
    }
}
