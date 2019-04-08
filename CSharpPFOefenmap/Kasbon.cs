﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Kasbon: ISpaarmiddel
    {
        private readonly DateTime EersteAankoop = new DateTime(1900, 1, 1);
        private DateTime aankoopDatumValue;
        private decimal bedragValue, intrestValue;
        private int looptijdValue;
        public DateTime AankoopDatum
        {
            get
            {
                return aankoopDatumValue;
            }
            set
            {
                if (value >= EersteAankoop)
                {
                    aankoopDatumValue = value;
                }
            }
        }
        public decimal Bedrag
        {
            get
            {
                return bedragValue;
            }
            set
            {
                if (value > 0)
                {
                    bedragValue = value;
                }
            }
        }
        public int Looptijd
        {
            get
            {
                return looptijdValue;
            }
            set
            {
                if (value > 0)
                {
                    looptijdValue = value;
                }
            }
        }
        public decimal Intrest
        {
            get
            {
                return intrestValue;
            }
            set
            {
                if (value > 0m)
                {
                    intrestValue = value;
                }
            }
        }
        public Klant Eigenaar { get; set; }
        public Kasbon(DateTime aankoopDatum, decimal bedrag, int looptijd, decimal intrest, Klant eigenaar)
        {
            AankoopDatum = aankoopDatum;
            Bedrag = bedrag;
            Looptijd = looptijd;
            Intrest = intrest;
            Eigenaar = eigenaar;
        }
        public void Afbeelden()
        {
            if (Eigenaar != null)
            {
                Console.WriteLine("Eigenaar");
                Eigenaar.Afbeelden();
            }
            Console.WriteLine("Aankoopdatum: {0:d-MM-yyyy}", AankoopDatum);
            Console.WriteLine("Bedrag: {0}", Bedrag);
            Console.WriteLine("Looptijd: {0}", Looptijd);
            Console.WriteLine("Intrest: {0}", Intrest);
        }
    }
}
