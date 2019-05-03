using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voeding
{
    public enum Dessert
    {
        Tiramisu, Ijs, Cake
    }
    public enum Extra
    {
        Brood, Kaas, Look
    }
    public enum Grootte
    {
        Klein, Groot
    }
    public struct GegevensPizza
    {
        public List<string> onderdelen;
        public decimal prijs;
        public GegevensPizza(List<string> x, decimal y)
        {
            onderdelen = x;
            prijs = y;
        }
    }
    public struct GegevensPasta
    {
        public string omschrijving;
        public decimal prijs;
        public GegevensPasta(string x, decimal y)
        {
            omschrijving = x;
            prijs = y;
        }
    }
    public class Gerecht
    {
        public readonly static Dictionary<string, GegevensPizza> allePizzas = new Dictionary<string, GegevensPizza>
        {
            {"Margherita",
            new GegevensPizza(
                new List<string>{
                    "Tomatensaus",
                    "Mozzarella" },
                8m )},
            {"Napoli",
            new GegevensPizza(
                new List<string>{
                    "Tomatensaus",
                    "Mozzarella",
                    "Ansjovis",
                    "Kappers",
                    "Olijven" },
                10m )}
        };
        public readonly static Dictionary<string, GegevensPasta> allePastas = new Dictionary<string, GegevensPasta>
        {
        {"Lasagne",
            new GegevensPasta (
                "",
                15m )},
        {"Spaghetti Carbonara",
            new GegevensPasta (
                "spek, roomsaus en parmezaanse kaas",
                13m )},
        {"Spaghetti Bolognese",
            new GegevensPasta (
                "met gehaktsaus",
                12m)}
        };
    }
}
