using System;
using System.IO;
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
            string bestand = @"C:\Users\net07\Documents\CSharpPF\CSharpPFOefenmap\Twitter.obj";
            if (File.Exists(bestand))
                File.Delete(bestand);
            int keuze = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Maak een keuze:");
                Console.WriteLine("[1] Een twitterbericht plaatsen");
                Console.WriteLine("[2] Alle twitterberichten lezen");
                Console.WriteLine("[3] Twitterberichten van een persoon");
                Console.WriteLine("[0] Om te stoppen");
                while (!Int32.TryParse(Console.ReadLine(), out keuze) || (keuze < 0 || keuze > 3))
                {
                    Console.WriteLine("Gelieve een getal te kiezen dat in de keuzelijst staat");
                }
                switch (keuze)
                {
                    case 1:
                        Console.Write("Geef een naam: ");
                        string naam = Console.ReadLine();
                        Console.Write("Geef een bericht: ");
                        string bericht = Console.ReadLine();
                        Twitter.TweetPlaatsen(naam, bericht);
                        break;
                    case 2:
                        Console.WriteLine("Alle twitterberichten:");
                        Twitter.AlleTweetsTonen();
                        break;
                    case 3:
                        Console.Write("Geef de naam van een gebruiker: ");
                        var gebruiker = Console.ReadLine();
                        Console.WriteLine($"Tweets van gebruiker {gebruiker}:"); 
                        Twitter.TweetsVanUser(gebruiker);
                        break;
                }
            }
            while (keuze != 0);
        }
    }
}
