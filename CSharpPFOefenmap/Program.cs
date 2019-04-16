using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFOefenmap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var planten = new List<Plant> {
                new Plant {PlantID=1, Plantennaam="Tulp", Kleur="rood", Prijs=0.5m, Soort="bol" },
                new Plant {PlantID=2, Plantennaam="Krokus", Kleur="wit", Prijs=0.2m, Soort="bol"},
                new Plant {PlantID=3, Plantennaam="Narcis", Kleur="geel", Prijs=0.3m, Soort="bol"},
                new Plant {PlantID=4, Plantennaam="Blauw druifje", Kleur="blauw", Prijs=0.2m, Soort="bol"},
                new Plant {PlantID=5, Plantennaam="Azalea",Kleur="rood", Prijs=3m, Soort="heester"},
                new Plant {PlantID=6, Plantennaam="Forsythia", Kleur="geel", Prijs=2m, Soort="heester"},
                new Plant {PlantID=7, Plantennaam="Magnolia", Kleur="wit", Prijs=4m, Soort="heester"},
                new Plant {PlantID=8, Plantennaam="Waterlelie", Kleur="wit", Prijs=2m,Soort="water"},
                new Plant {PlantID=9, Plantennaam="Lisdodde", Kleur="geel", Prijs=3m,Soort="water"},
                new Plant {PlantID=10,Plantennaam="Kalmoes", Kleur="geel", Prijs=2.5m, Soort="water"},
                new Plant {PlantID=11,Plantennaam="Bieslook", Kleur="paars", Prijs=1.5m,Soort="kruid"},
                new Plant {PlantID=12,Plantennaam="Rozemarijn", Kleur="blauw", Prijs=1.25m, Soort="kruid"},
                new Plant {PlantID=13,Plantennaam="Munt", Kleur="wit", Prijs=1.1m, Soort="kruid"},
                new Plant {PlantID=14,Plantennaam="Dragon", Kleur="wit", Prijs=1.3m, Soort="kruid"},
                new Plant {PlantID=15,Plantennaam="Basilicum", Kleur="wit", Prijs=1.5m, Soort="kruid"}
            };

            var gegevensWittePlanten = from plant in planten where plant.Kleur == "wit" orderby plant.Prijs select plant;
            foreach (var plant in gegevensWittePlanten)
            {
                Console.WriteLine($"{plant.Plantennaam}, {plant.Kleur}, {plant.Prijs} euro");
            }
            Console.WriteLine();

            var aantalWittePlanten = (from plant in planten where plant.Kleur == "wit" select plant.PlantID).Count();
            Console.WriteLine($"Aantal witte planten: {aantalWittePlanten}");
            Console.WriteLine();

            var gemiddeldePrijsHeesters = (from plant in planten where plant.Soort == "heester" select plant.Prijs).Average();
            Console.WriteLine($"Gemiddelde prijs heesters: {gemiddeldePrijsHeesters}");
            Console.WriteLine();

            var prijzenKruiden = from plant in planten where plant.Soort == "kruid" select plant.Prijs;
            var gemiddeldePrijsKruiden = prijzenKruiden.Average();
            var maxPrijsKruiden = prijzenKruiden.Max();
            Console.WriteLine($"Gemiddelde prijs kruiden: {gemiddeldePrijsKruiden}");
            Console.WriteLine($"Maximum prijs kruiden: {maxPrijsKruiden}");
            Console.WriteLine();

            var plantennamenStartWithB = from plant in planten where plant.Plantennaam.StartsWith("B") select plant.Plantennaam;
            Console.WriteLine("Starten met B:");
            foreach (var plant in plantennamenStartWithB) Console.WriteLine(plant);
            Console.WriteLine();

            var alleVerschillendeKleuren = (from plant in planten select plant.Kleur).Distinct();
            Console.WriteLine("Alle verschillende kleuren:");
            foreach (var kleur in alleVerschillendeKleuren) Console.WriteLine(kleur);
            Console.WriteLine();

            var plantenPerKleur = from plant in planten group plant by plant.Kleur;
            Console.WriteLine("ALLE PLANTEN PER KLEUR:");
            foreach (var kleur in plantenPerKleur)
            {
                Console.WriteLine("Kleur " + kleur.Key.ToUpper() + ":");
                foreach (var plant in kleur)
                {
                    Console.WriteLine("\t" + plant.Plantennaam);
                }
            }
            Console.WriteLine();

            var plantenPerSoort = from plant in planten group plant by plant.Soort;
            Console.WriteLine("Maximum prijzen per soort:");
            foreach (var soort in plantenPerSoort)
            {
                Console.Write(soort.Key + ": ");
                var maxPrijs = (from plant in soort select plant.Prijs).Max();
                Console.WriteLine(maxPrijs);
            }
            Console.WriteLine();

            Console.WriteLine("Soorten alfabetisch:");
            var soortenAlfabetisch = from plant in planten orderby plant.Soort
                                     group plant by plant.Soort
                                     into soortgroep
                                     select new {Soortnaam = soortgroep.Key,
                                         AantalPlanten = soortgroep.Count(),
                                         Planten = soortgroep};
            foreach (var soort in soortenAlfabetisch)
            {
                Console.WriteLine($"{soort.Soortnaam} ({soort.AantalPlanten})");
                foreach (var plant in soort.Planten)
                {
                    Console.WriteLine($"\t {plant.Plantennaam}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("PLANTEN per SOORT per KLEUR");
            var groepenPerSoortKleur = from plant in planten
                                       group plant by plant.Soort
                                       into soortgroep
                                       select new
                                       {
                                           Soort = soortgroep.Key,
                                           GroepKleur = from plant in soortgroep
                                                        group plant by plant.Kleur
                                                        into kleurgroep
                                                        select new
                                                        {
                                                            Kleur = kleurgroep.Key,
                                                            Planten = kleurgroep
                                                        }
                                       };
            foreach (var soort in groepenPerSoortKleur)
            {
                Console.WriteLine($"Soort: {soort.Soort}");
                foreach (var kleur in soort.GroepKleur)
                {
                    Console.WriteLine($"    Kleur: {kleur.Kleur}");
                    foreach (var plant in kleur.Planten)
                        Console.WriteLine($"       {plant.Plantennaam}");
                }
            }
        }
    }
}
