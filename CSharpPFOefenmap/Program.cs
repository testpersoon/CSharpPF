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
            var tweet1 = new Tweet { Naam = "jef", Bericht = "tweet 1", Tijdstip = new DateTime(2019, 04, 10) };
            var tweet2 = new Tweet { Naam = "jos", Bericht = "tweet 1", Tijdstip = DateTime.Now };
            var tweet3 = new Tweet { Naam = "john", Bericht = "tweet 2", Tijdstip = new DateTime(2019, 04, 18) };
            Twitter.TweetPlaatsen(tweet3);
            Twitter.TweetPlaatsen(tweet2);
            Twitter.TweetPlaatsen(tweet1);

            Twitter.AlleTweetsTonen();
        }
    }
}
