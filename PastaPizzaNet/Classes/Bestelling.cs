﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PastaPizzaNet.Classes
{
    public class Bestelling:IBedrag
    {
        public Klant Klant { get; set; }
        public BesteldGerecht BesteldGerecht { get; set; }
        public Drank Drank { get; set; }
        public Dessert Dessert { get; set; }
        public int Aantal { get; set; } = 1;
        public decimal BerekenBedrag()
        {
            decimal bedrag = 0m;
            bedrag += (BesteldGerecht != null ? BesteldGerecht.BerekenBedrag() : 0m)
                + (Drank != null ? Drank.BerekenBedrag() : 0m)
                + (Dessert != null ? Dessert.BerekenBedrag() : 0m);
            if (BesteldGerecht != null
                && Drank != null
                && Dessert != null)
                bedrag *= 0.9m;
            return bedrag * Aantal;
        }
        public override string ToString()
        {
            string klantNaam = Klant == null ? "Onbekende klant" : Klant.ToString();
            string besteldGerecht = BesteldGerecht == null ? "" : ("Gerecht: " + BesteldGerecht.ToString() + "\n");
            string drank = Drank == null ? "" : ("Drank: " + Drank.ToString() + "\n");
            string dessert = Dessert == null ? "" : ("Dessert: " + Dessert.ToString() + "\n");
            string output = "" +
                ($"Klant: {klantNaam}\n" + 
                $"{besteldGerecht}" +
                $"{drank}" +
                $"{dessert}" +
                $"Aantal: {Aantal}\n" +
                $"Bedrag van deze bestelling: {BerekenBedrag()} euro");
            return output;
        }
    }
}