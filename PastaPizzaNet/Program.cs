using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voeding;

namespace PastaPizzaNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var janJanssen = new Klant("Jan Janssen");
            var pietPeeters = new Klant("Piet Peeters");
            Bestellingen.BestellingPlaatsen(
                klant: janJanssen,
                gerecht: new BesteldGerecht(new Pizza("Margherita"), Grootte.Groot, aantalKaas: 1, aantalLook: 1),
                drank: new Frisdrank(Voeding.Drank.Water),
                dessert: new Dessert(Voeding.Dessert.Ijs),
                aantal: 2);
            Bestellingen.BestellingPlaatsen(
                klant: pietPeeters,
                gerecht: new BesteldGerecht(new Pizza("Margherita")),
                drank: new Frisdrank(Voeding.Drank.Water),
                dessert: new Dessert(Voeding.Dessert.Tiramisu));
            Bestellingen.BestellingPlaatsen(
                klant: pietPeeters,
                gerecht: new BesteldGerecht(new Pizza("Napoli"), Grootte.Groot),
                drank: new Warmedrank(Voeding.Drank.Thee),
                dessert: new Dessert(Voeding.Dessert.Ijs));
            Bestellingen.BestellingPlaatsen(
                gerecht: new BesteldGerecht(new Pasta("Lasagne"), aantalLook: 1));
            Bestellingen.BestellingPlaatsen(
                klant: janJanssen,
                gerecht: new BesteldGerecht(new Pasta("Spaghetti Carbonara")),
                drank: new Frisdrank(Voeding.Drank.CocaCola));
            Bestellingen.BestellingPlaatsen(
                klant: pietPeeters,
                gerecht: new BesteldGerecht(new Pasta("Spaghetti Bolognese"), Grootte.Groot, aantalKaas: 1),
                drank: new Frisdrank(Voeding.Drank.CocaCola),
                dessert: new Dessert(Voeding.Dessert.Cake));
            Bestellingen.BestellingPlaatsen(
                klant: pietPeeters,
                drank: new Warmedrank(Voeding.Drank.Koffie),
                aantal: 3);
            Bestellingen.BestellingPlaatsen(
                klant: janJanssen,
                dessert: new Dessert(Voeding.Dessert.Tiramisu));

            Bestellingen.Tonen();
            //Bestellingen.TonenVanKlant(janJanssen);
            //Bestellingen.TonenPerKlant();
        }
    }
}
