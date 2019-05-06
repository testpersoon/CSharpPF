using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastaPizzaNet.Classes;
using PastaPizzaNet;

namespace PastaPizzaNet
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pizza's*/
            var pizzaMargherita = new Pizza { Naam = "Pizza Margherita", Prijs = 8m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" } };
            var pizzaNapoli = new Pizza { Naam = "Pizza Napoli", Prijs = 10m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven" } };

            /*Pasta's*/
            var pastaLasagne = new Pasta { Naam = "Lasagne", Omschrijving = "", Prijs = 15m };
            var pastaCarbonara = new Pasta { Naam = "Spaghetti Carbonara", Omschrijving = "spek, roomsaus en parmezaanse kaas", Prijs = 13m };
            var pastaBolognese = new Pasta { Naam = "Spaghetti Bolognese", Omschrijving = "met gehaktsaus", Prijs = 12m };

            /*Groottes*/
            var groot = Enums.Grootte.Groot;
            //var klein = Enums.Grootte.Klein;

            /*Extras*/
            var kaas = Enums.Extra.Kaas;
            var look = Enums.Extra.Look;
            //var brood = Enums.Extra.Brood;

            /*Klanten*/
            var janJanssen = new Klant { Naam = "Jan Janssen", KlantID = 1 };
            var pietPeeters = new Klant { Naam = "Piet Peeters", KlantID = 2 };

            /*Desserts*/
            Dessert tiramisu = null, ijs = null, cake = null;
            try
            {
                tiramisu = new Dessert { Naam = Enums.Dessert.Tiramisu };
                ijs = new Dessert { Naam = Enums.Dessert.Ijs };
                cake = new Dessert { Naam = Enums.Dessert.Cake };
            }
            catch (PrijsVanDessertNietGevonden ex)
            {
                Console.WriteLine("Fout: {0} {1}\n{2}", ex.Message, ex.VerkeerdDessert, ex.StackTrace);
            }
            catch (GeenFrisdrankException ex)
            {
                Console.WriteLine("Fout: {0} {1}\n{2}", ex.Message, ex.VerkeerdeDrank, ex.StackTrace);
            }
            catch (GeenWarmeDrankException ex)
            {
                Console.WriteLine("Fout: {0} {1}\n{2}", ex.Message, ex.VerkeerdeDrank, ex.StackTrace);
            }

            /*Dranken*/
            var water = new Frisdrank { Naam = Enums.Drank.Water };
            var limonade = new Frisdrank { Naam = Enums.Drank.Limonade };
            var cocaCola = new Frisdrank { Naam = Enums.Drank.CocaCola };
            var koffie = new WarmeDrank { Naam = Enums.Drank.Koffie };
            var thee = new WarmeDrank { Naam = Enums.Drank.Thee };

            /*Lijst bestellingen maken*/
            var lijstBestellingen = new List<Bestelling> {
                new Bestelling {
                    Klant = janJanssen,
                    BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita, Grootte = groot, Extras = new List<Enums.Extra> { kaas, look } },
                    Drank = water,
                    Dessert = ijs,
                    Aantal = 2
                },
                new Bestelling
                {
                    Klant = pietPeeters,
                    BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita },
                    Drank = water,
                    Dessert = tiramisu
                },
                new Bestelling
                {
                    Klant = pietPeeters,
                    BesteldGerecht = new BesteldGerecht { Gerecht = pizzaNapoli, Grootte = groot },
                    Drank = thee,
                    Dessert = ijs
                },
                new Bestelling
                {
                    BesteldGerecht = new BesteldGerecht { Gerecht = pastaLasagne, Extras = new List<Enums.Extra> { look } }
                },
                new Bestelling
                {
                    Klant = janJanssen,
                    BesteldGerecht = new BesteldGerecht { Gerecht = pastaCarbonara },
                    Drank = cocaCola
                },
                new Bestelling
                {
                    Klant = pietPeeters,
                    BesteldGerecht = new BesteldGerecht { Gerecht = pastaBolognese, Grootte = groot, Extras = new List<Enums.Extra> { kaas } },
                    Drank = cocaCola,
                    Dessert = cake
                },
                new Bestelling
                {
                    Klant = pietPeeters,
                    Drank = koffie,
                    Aantal = 3
                },
                new Bestelling
                {
                    Klant = janJanssen,
                    Dessert = tiramisu
                }
            };

            /*Bestellingen toevoegen*/
            foreach (var bestelling in lijstBestellingen)
                Bestellingen.Toevoegen(bestelling);
            


            Console.WriteLine(Bestellingen.Tonen());
            //Console.WriteLine(Bestellingen.TonenVanKlant(janJanssen));
            //Console.WriteLine(Bestellingen.TonenPerKlant());
        }
    }
}
