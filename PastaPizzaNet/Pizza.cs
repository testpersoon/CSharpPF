using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        private Pizza(string naam):base()
        {
            Naam = naam;
        }
        private string naamValue;
        public override string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (pizzas.Contains(value)){
                    naamValue = value;
                    this.Onderdelen = pizzas[this.Naam].onderdelen;
                    this.Prijs = pizzas[this.Naam].prijs;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Pizzanaam: \"{value}\" bestaat niet.");
                };
            }
        }
        public override decimal Prijs { get; set; }
        private List<string> Onderdelen { get; set; }
        private struct Gegevens
        {
            public List<string> onderdelen;
            public decimal prijs;
            public Gegevens(List<string> x, decimal y)
            {
                onderdelen = x;
                prijs = y;
            }
        }
        private readonly static Dictionary<string, Gegevens> pizzas = new Dictionary<string, Gegevens>
        {
            {"Margherita",
            new Gegevens (
                new List<string>{
                    "Tomatensaus",
                    "Mozzarella" },
                8m ) //<------ De prijs
            },
            {"Napoli",
            new Gegevens (
                new List<string>{
                    "Tomatensaus",
                    "Mozzarella",
                    "Ansjovis",
                    "Kappers",
                    "Olijven" },
                10m )
            }
        };
    }
}
