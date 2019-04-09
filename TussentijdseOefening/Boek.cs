using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TussentijdseOefening
{
    public abstract class Boek : IVoorwerpen
    {
        public Boek(string titel, string auteur, decimal aankoopprijs, Genre genre)
        {
            Titel = titel;
            Auteur = auteur;
            Aankoopprijs = aankoopprijs;
            Genre = genre;
        }

        static readonly string Eigenaar = "VDAB";
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public Genre Genre { get; set; }
        private decimal aankoopprijsValue;
        public decimal Aankoopprijs
        {
            get
            {
                return aankoopprijsValue;
            }
            set
            {
                if (value > 0)
                {
                    aankoopprijsValue = value;
                }
            }
        }

        public abstract decimal Winst
        {
            get;
        }

        public virtual void GegevensTonen()
        {
            Console.WriteLine($"Titel: {Titel}");
            Console.WriteLine($"Auteur: {Auteur}");
            Console.WriteLine($"Eigenaar: {Eigenaar}");
            Console.WriteLine($"Aankoopprijs: {Math.Round(Aankoopprijs,2)} euro");
            Console.WriteLine($"Genre: {Genre}");
        }
    }
}
