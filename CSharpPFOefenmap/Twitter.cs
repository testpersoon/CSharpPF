﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace CSharpPFOefenmap
{
    public class Twitter
    {
        const string bestandLocatie = @"C:\Users\net07\Documents\CSharpPF\CSharpPFOefenmap\Twitter.obj";
        public static void TweetPlaatsen(string naam, string bericht)
        {
            var tweet = new Tweet { Naam = naam, Bericht = bericht, Tijdstip = DateTime.Now };
            if (File.Exists(bestandLocatie))
            {
                try
                {
                    Tweets tweets;
                    using (var bestand = File.Open(bestandLocatie, FileMode.Open, FileAccess.Read))
                    {
                        var lezer = new BinaryFormatter();
                        tweets = (Tweets)lezer.Deserialize(bestand);
                        tweets.AddTweet(tweet);
                    }
                    using (var bestand = File.Open(bestandLocatie, FileMode.Create))
                    {
                        var schrijver = new BinaryFormatter();
                        schrijver.Serialize(bestand, tweets);
                        Console.WriteLine("Tweet succesvol geplaatst!");
                    }
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Fout bij het serialiseren/deserialiseren");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    using (var bestand = File.Open(bestandLocatie, FileMode.Create))
                    {
                        var schrijver = new BinaryFormatter();
                        var tweets = new Tweets();
                        tweets.AddTweet(tweet);
                        schrijver.Serialize(bestand, tweets);
                        Console.WriteLine("Tweet succesvol geplaatst!");
                    }
                }
                catch (IOException)
                {
                    throw new Exception("Fout bij het maken van het bestand");
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Fout bij het serialiseren");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void AlleTweetsTonen()
        {
            if (File.Exists(bestandLocatie))
            {
                try
                {
                    using (var bestand = File.Open(bestandLocatie, FileMode.Open, FileAccess.Read))
                    {
                        var lezer = new BinaryFormatter();
                        var tweets = (Tweets)lezer.Deserialize(bestand);
                        //var tweetsChronologisch = (from tweet in tweets.AlleTweets() orderby tweet.Tijdstip descending select tweet);
                        var tweetsChronologisch = tweets.AlleTweets().OrderByDescending(t => t.Tijdstip).ToList();
                        foreach (Tweet tweet in tweetsChronologisch)
                        {
                            Console.WriteLine(tweet.ToString());
                        }
                    }
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Fout bij het serialiseren/deserialiseren");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void TweetsVanUser(string naam)
        {
            if (File.Exists(bestandLocatie))
            {
                try
                {
                    using (var bestand = File.Open(bestandLocatie, FileMode.Open, FileAccess.Read))
                    {
                        var lezer = new BinaryFormatter();
                        Tweets tweets = (Tweets)lezer.Deserialize(bestand);
                        List<Tweet> tweetsGebruiker = tweets.AlleTweets().Where(n => n.Naam == naam).ToList();
                        tweetsGebruiker = tweetsGebruiker.OrderByDescending(t => t.Tijdstip).ToList();
                        foreach (Tweet foo in tweetsGebruiker)
                        {
                            Console.WriteLine(foo.ToString());
                        }
                    }
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Fout bij het serialiseren/deserialiseren");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
