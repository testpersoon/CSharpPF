using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public abstract class Werknemer: IKost
    {
        public Werknemer() : this("Onbekend", DateTime.Today, Geslacht.Man)
        {
        }

        public Werknemer(string naam, DateTime inDienst, Geslacht geslacht)
        {
            this.Naam = naam;
            this.InDienst = inDienst;
            this.Geslacht = geslacht;
        }

        public WerkRegime Regime { get; set; }
        public static DateTime Personeelsfeest { get; set; }

        public DateTime InDienst { get; set; }

        public Geslacht Geslacht { get; set; }

        public Afdeling Afdeling { get; set; }

        public abstract decimal Premie
        {
            get;
        }

        private string naamValue;
        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (value != string.Empty)
                    naamValue = value;
            }
        }

        public bool VerjaarAncien
        {
            get
            {
                return InDienst.Month == DateTime.Today.Month && InDienst.Day == DateTime.Today.Day;
            }
        }

        public abstract decimal Bedrag
        {
            get;
        }

        public bool Menselijk
        {
            get
            {
                return true;
            }
        }


        public virtual void Afbeelden()
        {
            Console.WriteLine("Naam: {0}", Naam);
            Console.WriteLine("Geslacht: {0}", Geslacht);
            Console.WriteLine("In dienst: {0}", InDienst);
            Console.WriteLine("Personeelsfeest: {0}", Personeelsfeest);
            if (Afdeling != null)
                Console.WriteLine(Afdeling);
        }

        public override string ToString()
        {
            return Naam + " " + Geslacht;
        }

        public override bool Equals(object obj)
        {
            if (obj is Werknemer)
            {
                Werknemer deAndere = (Werknemer)obj;
                return this.Naam == deAndere.Naam;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Naam.GetHashCode();
        }

        public class WerkRegime
        {
            public enum RegimeType
            {
                Voltijds, Viervijfde, Halftijds
            }
            public RegimeType Type { get; set; }
            public int AantalVakantiedagen
            {
                get
                {
                    switch (Type)
                    {
                        case RegimeType.Voltijds:
                            return 25;
                        case RegimeType.Viervijfde:
                            return 20;
                        case RegimeType.Halftijds:
                            return 12;
                        default:
                            return 0;
                    }
                }
            }
            public WerkRegime(RegimeType type)
            {
                Type = type;
            }
            public override string ToString()
            {
                return Type.ToString();
            }
        }
        public DateTime[] Verlofdagen { get; set; }
        public DateTime[] Ziektedagen { get; set; }
    }
}
