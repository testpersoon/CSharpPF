using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PastaPizzaNet.Classes;
using System.IO;

namespace PastaPizzaNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string locatie = Directory.GetCurrentDirectory();

            /*Klanten*/
            var janJanssen = new Klant { Naam = "Jan Janssen", KlantID = 1 };
            var pietPeeters = new Klant { Naam = "Piet Peeters", KlantID = 2 };
            var lijstKlanten = new List<Klant> { janJanssen, pietPeeters };

            AlleInfoGenereren(lijstKlanten, out List<Gerecht> lijstGerechten);
            AlleInfoWegschrijvenNaarTekstbestand(lijstKlanten, lijstGerechten, Bestellingen.AlleBestellingen(), locatie);
            //AlleInfoInlezenVanTekstbestand(locatie);

            Console.WriteLine(Bestellingen.Tonen());
            //Console.WriteLine(Bestellingen.TonenVanKlant(janJanssen));
            //Console.WriteLine(Bestellingen.TonenPerKlant());
        }
        public static void AlleInfoGenereren(List<Klant> lijstKlanten, out List<Gerecht> lijstGerechten)
        {
            /*Pizza's*/
            var pizzaMargherita = new Pizza { Naam = "Pizza Margherita", Prijs = 8m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" } };
            var pizzaNapoli = new Pizza { Naam = "Pizza Napoli", Prijs = 10m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven" } };
            var pizzaLardiera = new Pizza { Naam = "Pizza Lardiera", Prijs = 9.5m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Spek" } };
            var pizzaVegetariana = new Pizza { Naam = "Pizza Vegetariana", Prijs = 9.5m, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Groenten" } };

            /*Pasta's*/
            var pastaBolognese = new Pasta { Naam = "Spaghetti Bolognese", Omschrijving = "met gehaktsaus", Prijs = 12m };
            var pastaCarbonara = new Pasta { Naam = "Spaghetti Carbonara", Omschrijving = "spek, roomsaus en parmezaanse kaas", Prijs = 13m };
            var pastaArrabbiata = new Pasta { Naam = "Penne Arrabbiata", Omschrijving = "met pittige tomatensaus", Prijs = 14m };
            var pastaLasagne = new Pasta { Naam = "Lasagne", Omschrijving = "", Prijs = 15m };
            lijstGerechten = new List<Gerecht> { pizzaMargherita, pizzaNapoli, pizzaLardiera, pizzaVegetariana, pastaBolognese, pastaCarbonara, pastaArrabbiata, pastaLasagne };

            /*Groottes*/
            var groot = Enums.Grootte.Groot;
            //var klein = Enums.Grootte.Klein;

            /*Extras*/
            var kaas = Enums.Extra.Kaas;
            var look = Enums.Extra.Look;
            //var brood = Enums.Extra.Brood;

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
                    Klant = lijstKlanten[0],
                    BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita, Grootte = groot, Extras = new List<Enums.Extra> { kaas, look } },
                    Drank = water,
                    Dessert = ijs,
                    Aantal = 2
                },
                new Bestelling
                {
                    Klant = lijstKlanten[1],
                    BesteldGerecht = new BesteldGerecht { Gerecht = pizzaMargherita },
                    Drank = water,
                    Dessert = tiramisu
                },
                new Bestelling
                {
                    Klant = lijstKlanten[1],
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
                    Klant = lijstKlanten[0],
                    BesteldGerecht = new BesteldGerecht { Gerecht = pastaCarbonara },
                    Drank = cocaCola
                },
                new Bestelling
                {
                    Klant = lijstKlanten[1],
                    BesteldGerecht = new BesteldGerecht { Gerecht = pastaBolognese, Grootte = groot, Extras = new List<Enums.Extra> { kaas } },
                    Drank = cocaCola,
                    Dessert = cake
                },
                new Bestelling
                {
                    Klant = lijstKlanten[1],
                    Drank = koffie,
                    Aantal = 3
                },
                new Bestelling
                {
                    Klant = lijstKlanten[0],
                    Dessert = tiramisu
                }
            };
            /*Bestellingen toevoegen aan class*/
            foreach (var bestelling in lijstBestellingen)
            {
                Bestellingen.Toevoegen(bestelling);
            }
        }
        public static void AlleInfoWegschrijvenNaarTekstbestand(List<Klant> lijstKlanten, List<Gerecht> lijstGerechten, IReadOnlyCollection<Bestelling> lijstBestellingen, string locatie)
        {
            try
            {
                using (var schrijver = new StreamWriter(locatie + @"\klanten.txt", false))
                {
                    foreach (var klant in lijstKlanten.OrderBy(k => k.KlantID))
                    {
                        schrijver.WriteLine(klant.StringOmWegTeSchrijven());
                    }
                    Console.WriteLine("Succes! De klanten zijn weggeschreven.");
                }
                using (var schrijver = new StreamWriter(locatie + @"\gerechten.txt", false))
                {
                    foreach (var gerecht in lijstGerechten)
                    {
                        schrijver.WriteLine(gerecht.StringOmWegTeSchrijven());
                    }
                    Console.WriteLine("Succes! De gerechten zijn weggeschreven.");
                }
                using (var schrijver = new StreamWriter(locatie + @"\bestellingen.txt", false))
                {
                    foreach (var bestelling in Bestellingen.AlleBestellingen())
                    {
                        schrijver.WriteLine(bestelling.StringOmWegTeSchrijven());
                    }
                    Console.WriteLine("Succes! De bestellingen zijn weggeschreven.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Fout bij het schrijven naar een bestand!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void AlleInfoInlezenVanTekstbestand(string locatie)
        {
            List<Klant> lijstKlantenExtern = new List<Klant>();
            List<Gerecht> lijstGerechtenExtern = new List<Gerecht>();
            List<Bestelling> lijstBestellingenExtern = new List<Bestelling>();
            try
            {
                lijstKlantenExtern = KlantenInlezen(locatie);
                lijstGerechtenExtern = GerechtenInlezen(locatie);
                lijstBestellingenExtern = BestellingenInlezen(lijstKlantenExtern, lijstGerechtenExtern, locatie);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Tekstbestand niet gevonden.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Fout bij het lezen van het tekstbestand!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*Ingelezen bestellingen toevoegen*/
            foreach (var bestelling in lijstBestellingenExtern)
            {
                Bestellingen.Toevoegen(bestelling);
            }
        }
        public static List<Klant> KlantenInlezen(string locatie)
        {
            List<Klant> lijstKlanten = new List<Klant>();
            using (var lezer = new StreamReader(locatie + @"\klanten.txt"))
            {
                string regel;
                while ((regel = lezer.ReadLine()) != null)
                {
                    string[] gegevens = regel.Split(new Char[] { '#' });
                    var klant = new Klant { KlantID = int.Parse(gegevens[0]), Naam = gegevens[1] };
                    lijstKlanten.Add(klant);
                }
            }
            return lijstKlanten;
        }
        public static List<Gerecht> GerechtenInlezen(string locatie)
        {
            List<Gerecht> lijstGerechten = new List<Gerecht>();
            using (var lezer = new StreamReader(locatie + @"\gerechten.txt"))
            {
                string naam, pastaOmschrijving, regel, typeGerecht;
                decimal prijs;
                Gerecht gerecht;
                while ((regel = lezer.ReadLine()) != null)
                {
                    string[] gegevens = regel.Split(new Char[] { '#' });
                    typeGerecht = gegevens[0];
                    naam = gegevens[1];
                    prijs = decimal.Parse(gegevens[2]);
                    switch (Enum.Parse(typeof(Enums.TypeGerecht), typeGerecht))
                    {
                        case Enums.TypeGerecht.pizza:
                            var pizzaOnderdelen = new List<string>();
                            for (var i = 3; i < gegevens.Length; i++)
                            {
                                pizzaOnderdelen.Add(gegevens[i]);
                            }
                            gerecht = new Pizza { Naam = naam, Prijs = prijs, Onderdelen = pizzaOnderdelen };
                            lijstGerechten.Add(gerecht);
                            break;
                        case Enums.TypeGerecht.pasta:
                            pastaOmschrijving = gegevens[3];
                            gerecht = new Pasta { Naam = naam, Prijs = prijs, Omschrijving = pastaOmschrijving };
                            lijstGerechten.Add(gerecht);
                            break;
                    }
                }
            }
            return lijstGerechten;
        }
        public static List<Bestelling> BestellingenInlezen(List<Klant> lijstKlanten, List<Gerecht> lijstGerechten, string locatie)
        {
            List<Bestelling> lijstBestellingen = new List<Bestelling>();
            using (var lezer = new StreamReader(locatie + @"\bestellingen.txt"))
            {
                string regel;
                while ((regel = lezer.ReadLine()) != null)
                {
                    Bestelling bestelling = new Bestelling();
                    string[] gegevens = regel.ToUpper().Split(new Char[] { '#' });
                    int klantID = int.Parse(gegevens[0]);
                    //Klant
                    if (klantID != 0)
                        bestelling.Klant = lijstKlanten.First(k => k.KlantID == klantID);
                    //Besteld gerecht
                    if (gegevens[1].Length > 0)
                    {
                        var besteldGerecht = new BesteldGerecht();
                        string[] gegevensGerecht = gegevens[1].Split(new char[] { '-' });
                        besteldGerecht.Gerecht = lijstGerechten.FirstOrDefault(n => n.Naam.ToUpper() == gegevensGerecht[0]);
                        if (gegevensGerecht[1] == "GROOT")
                            besteldGerecht.Grootte = Enums.Grootte.Groot;
                        if (gegevensGerecht[2] != "0")
                        {
                            var extras = new List<Enums.Extra>();
                            for (var i = 3; i < gegevensGerecht.Length; i++)
                            {
                                extras.Add((Enums.Extra)Enum.Parse(typeof(Enums.Extra), gegevensGerecht[i]));
                            }
                            besteldGerecht.Extras = extras;
                        }
                        bestelling.BesteldGerecht = besteldGerecht;
                    }
                    //Drank
                    if (gegevens[2].Length > 0)
                    {
                        string[] gegevensDrank = gegevens[2].Split(new char[] { '-' });
                        switch (gegevensDrank[0])
                        {
                            case "F":
                                bestelling.Drank = new Frisdrank { Naam = (Enums.Drank)Enum.Parse(typeof(Enums.Drank), gegevensDrank[1]) };
                                break;
                            case "W":
                                bestelling.Drank = new WarmeDrank { Naam = (Enums.Drank)Enum.Parse(typeof(Enums.Drank), gegevensDrank[1]) };
                                break;
                        }
                    }
                    //Dessert
                    if (gegevens[3].Length > 0)
                    {
                        bestelling.Dessert = new Dessert { Naam = (Enums.Dessert)Enum.Parse(typeof(Enums.Dessert), gegevens[3]) };
                    }
                    bestelling.Aantal = int.Parse(gegevens[4]);
                    lijstBestellingen.Add(bestelling);
                }
            }
            return lijstBestellingen;
        }
    }
}
