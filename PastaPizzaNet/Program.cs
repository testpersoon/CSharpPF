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
            var lijstGerechten = new List<Gerecht> { pizzaMargherita, pizzaNapoli, pizzaLardiera, pizzaVegetariana, pastaBolognese, pastaCarbonara, pastaArrabbiata, pastaLasagne };

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
            var lijstKlanten = new List<Klant> { janJanssen, pietPeeters };

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
            //foreach (var bestelling in lijstBestellingen)
            //{
            //    Bestellingen.Toevoegen(bestelling);
            //}



            ////Console.WriteLine(Bestellingen.Tonen());
            //Console.WriteLine(Bestellingen.TonenVanKlant(janJanssen));
            //Console.WriteLine(Bestellingen.TonenPerKlant());

            string locatie = Directory.GetCurrentDirectory();
            //try
            //{
            //    using (var schrijver = new StreamWriter(locatie + @"\klanten.txt", false))
            //    {
            //        foreach (var klant in lijstKlanten.OrderBy(k => k.KlantID))
            //        {
            //            schrijver.WriteLine(klant.StringOmWegTeSchrijven());
            //        }
            //        Console.WriteLine("Succes! De klanten zijn weggeschreven.");
            //    }
            //    using (var schrijver = new StreamWriter(locatie + @"\gerechten.txt", false))
            //    {
            //        foreach (var gerecht in lijstGerechten)
            //        {
            //            schrijver.WriteLine(gerecht.StringOmWegTeSchrijven());
            //        }
            //        Console.WriteLine("Succes! De gerechten zijn weggeschreven.");
            //    }
            //    using (var schrijver = new StreamWriter(locatie + @"\bestellingen.txt", false))
            //    {
            //        foreach (var bestelling in Bestellingen.AlleBestellingen())
            //        {
            //            schrijver.WriteLine(bestelling.StringOmWegTeSchrijven());
            //        }
            //        Console.WriteLine("Succes! De bestellingen zijn weggeschreven.");
            //    }
            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Fout bij het schrijven naar het bestand!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            List<Klant> lijstKlantenExtern = new List<Klant>();
            try
            {
                using (var lezer = new StreamReader(locatie + @"\klanten.txt"))
                {
                    string regel;
                    while ((regel = lezer.ReadLine()) != null)
                    {
                        string[] gegevens = regel.Split(new Char[] { '#' });
                        var klant = new Klant { KlantID = int.Parse(gegevens[0]), Naam = gegevens[1] };
                        lijstKlantenExtern.Add(klant);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klantenbestand niet gevonden.");
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het klantenbestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Gerecht> lijstGerechtenExtern = new List<Gerecht>();
            try
            {
                using (var lezer = new StreamReader(locatie + @"\gerechten.txt"))
                {
                    string naam, pastaOmschrijving, regel;
                    decimal prijs;
                    Gerecht gerecht;
                    while ((regel = lezer.ReadLine()) != null)
                    {
                        string[] gegevens = regel.Split(new Char[] { '#' });
                        naam = gegevens[1];
                        prijs = decimal.Parse(gegevens[2]);
                        switch (gegevens[0])
                        {
                            case "pizza":
                                var pizzaOnderdelen = new List<string>();
                                for (var i = 3; i < gegevens.Length; i++)
                                {
                                    pizzaOnderdelen.Add(gegevens[i]);
                                }
                                gerecht = new Pizza { Naam = naam, Prijs = prijs, Onderdelen = pizzaOnderdelen };
                                lijstGerechtenExtern.Add(gerecht);
                                break;
                            case "pasta":
                                pastaOmschrijving = gegevens[3];
                                gerecht = new Pasta { Naam = naam, Prijs = prijs, Omschrijving = pastaOmschrijving };
                                lijstGerechtenExtern.Add(gerecht);
                                break;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Gerechtenbestand niet gevonden.");
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het gerechtenbestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Bestelling> lijstBestellingenExtern = new List<Bestelling>();
            try
            {
                using (var lezer = new StreamReader(locatie + @"\bestellingen.txt"))
                {
                    string regel;
                    while ((regel = lezer.ReadLine()) != null)
                    {
                        Bestelling bestelling = new Bestelling();
                        string[] gegevens = regel.ToUpper().Split(new Char[] { '#' });
                        //Klant
                        if (gegevens[0] != "0")
                            bestelling.Klant = lijstKlantenExtern.First(k => k.KlantID == int.Parse(gegevens[0]));
                        //Besteld gerecht
                        if (gegevens[1].Length > 0)
                        {
                            var besteldGerecht = new BesteldGerecht();
                            string[] gegevensGerecht = gegevens[1].Split(new char[] { '-' });
                            besteldGerecht.Gerecht = lijstGerechtenExtern.FirstOrDefault(n => n.Naam.ToUpper() == gegevensGerecht[0]);
                            if (gegevensGerecht[1] == "GROOT")
                                besteldGerecht.Grootte = Enums.Grootte.Groot;
                            if (gegevensGerecht[2] != "0")
                            {
                                var extras = new List<Enums.Extra>();
                                for (var i = 3; i < gegevensGerecht.Length; i++)
                                {
                                    switch (gegevensGerecht[i])
                                    {
                                        case "BROOD":
                                            extras.Add(Enums.Extra.Brood);
                                            break;
                                        case "KAAS":
                                            extras.Add(Enums.Extra.Kaas);
                                            break;
                                        case "LOOK":
                                            extras.Add(Enums.Extra.Look);
                                            break;
                                    }
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
                                    switch (gegevensDrank[1])
                                    {
                                        case "WATER":
                                            bestelling.Drank = new Frisdrank { Naam = Enums.Drank.Water };
                                            break;
                                        case "LIMONADE":
                                            bestelling.Drank = new Frisdrank { Naam = Enums.Drank.Limonade };
                                            break;
                                        case "COCACOLA":
                                            bestelling.Drank = new Frisdrank { Naam = Enums.Drank.CocaCola };
                                            break;
                                    }
                                    break;
                                case "W":
                                    switch (gegevensDrank[1])
                                    {
                                        case "KOFFIE":
                                            bestelling.Drank = new WarmeDrank { Naam = Enums.Drank.Koffie };
                                            break;
                                        case "THEE":
                                            bestelling.Drank = new WarmeDrank { Naam = Enums.Drank.Thee };
                                            break;
                                    }
                                    break;
                            }
                        }
                        //Dessert
                        if (gegevens[3].Length > 0)
                        {
                            switch (gegevens[3])
                            {
                                case "TIRAMISU":
                                    bestelling.Dessert = new Dessert { Naam = Enums.Dessert.Tiramisu };
                                    break;
                                case "IJS":
                                    bestelling.Dessert = new Dessert { Naam = Enums.Dessert.Ijs };
                                    break;
                                case "CAKE":
                                    bestelling.Dessert = new Dessert { Naam = Enums.Dessert.Cake };
                                    break;
                            }
                        }
                        bestelling.Aantal = int.Parse(gegevens[4]);
                        lijstBestellingenExtern.Add(bestelling);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Bestellingenbestand niet gevonden.");
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het bestellingenbestand!");
            }
            catch (Exception ex)
            {
                Console.ReadLine();
                Console.WriteLine(ex.Message);
            }
            /*Ingelezen bestellingen toevoegen*/
            foreach (var bestelling in lijstBestellingenExtern)
            {
                Bestellingen.Toevoegen(bestelling);
            }

            Console.WriteLine(Bestellingen.Tonen());
            //Console.WriteLine(Bestellingen.TonenVanKlant(janJanssen));
            //Console.WriteLine(Bestellingen.TonenPerKlant());
        }
    }
}
