using System;
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
        const string twitterbestand = @"C:\Users\net07\Documents\CSharpPF\CSharpPFOefenmap\Twitter.obj";
        //alle tweets in omgekeerde chronologische volgorde
        public List<Tweet> AlleTweets()
        {
            if (File.Exists(twitterbestand))
            {
                var tweets = LeesTweets();
                return tweets.AlleTweets().OrderByDescending(
                t => t.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Het bestand " + twitterbestand + " is niet gevonden!");
            }
        }
        //Alle Tweets van één twitteraar
        public List<Tweet> TweetsVan(string naam)
        {
            return AlleTweets().Where(
            t => t.Naam.ToUpper() == naam.ToUpper()).ToList();
        }
        //Een tweet toevoegen
        public void SchrijfTweet(Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(twitterbestand))
            {
                //als het bestand bestaat,
                //eerst de verzameling van bestaande tweets inlezen
                tweets = LeesTweets();
            }
            else
            {
                tweets = new Tweets();
            }
            tweets.AddTweet(tweet);
            //de verzameling tweets wegschrijven
            SchrijfTweets(tweets);
        }
        //verzameling tweets inlezen uit bestand
        private Tweets LeesTweets()
        {
            try
            {
                using (var bestand = File.Open(twitterbestand,
                FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    return ((Tweets)lezer.Deserialize(bestand));
                }
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het openen van het bestand!");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het deserialiseren, " +
                "het twitterbestand kan niet meer geopend worden");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //verzameling tweets wegschrijven naar bestand
        private void SchrijfTweets(Tweets tweets)
        {
            try
            {
                using (var bestand = File.Open(twitterbestand,
                FileMode.OpenOrCreate))
                {
                    var schrijver = new BinaryFormatter();
                    schrijver.Serialize(bestand, tweets);
                }
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het openen van het bestand!");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het serialiseren");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
