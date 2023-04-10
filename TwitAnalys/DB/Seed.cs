using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.Windows.ApplicationModel;
using TwitAnalys.Models;

namespace TwitAnalys.DB
{
    public class Seed
    {
        private static TweetContext db = new TweetContext();

        public Seed(string ConnectionString)
        {
            //db = new TweetContext(ConnectionString);
        }
        public void Seeding(Tweet tweet) => db.Add(new SimplifiedTweet(tweet));
        public void Seeding(SimplifiedTweet tweet) => db.Add(tweet);
    }
}
