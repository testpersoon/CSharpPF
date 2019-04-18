using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpPFOefenmap
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> alleTweetsValue;
        public ReadOnlyCollection<Tweet> AlleTweets()
        {
            return new ReadOnlyCollection<Tweet>(alleTweetsValue);
        }
        public void AddTweet(Tweet tweet)
        {
            if (alleTweetsValue == null)
                alleTweetsValue = new List<Tweet>();
            alleTweetsValue.Add(tweet);
        }
    }
}