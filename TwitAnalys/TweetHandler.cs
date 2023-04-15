using System.Collections;
using TwitAnalys.DataLayer;
using TwitAnalys.DB;
using TwitAnalys.Models;
using TwitAnalys.View;
using System.Linq;
using System.Windows.Controls.Ribbon;
//using Microsoft.Web.WebView2.Core.Raw;

namespace TwitAnalys;

public class TweetHandler
{
    public static int count = 0;
    private static Seed SeedController;

    //public delegate void HandleTweet(Tweet tweet);
    
    public TweetHandler(/*string ConnectionString*/)
    {
        SeedController = new Seed();
        
    }
    public static void HandleAndCreate(Tweet tweet)
    {
        count++;
        CreateTweet.FillTweetSentiment(tweet); // make async
        if (count < 3000)GMapDraw.DrawMarkers(tweet);
        StateRepository.FillSentiment(tweet);
        SeedController.Seeding(tweet);
    }

    public static void Handle(/*string ConnectionString*/)
    {
        using (TweetContext db = new TweetContext(/*ConnectionString*/))
        {
            IEnumerable<SimplifiedTweet> Tweets = db.Tweets;
            Tweets.AsParallel().ForAll(tweet =>
            {
                StateRepository.FillSentiment(new Tweet(tweet));
            });
            Parallel.ForEach(Tweets.Take(3000), tweet =>
            {
                GMapDraw.DrawMarkers(new Tweet(tweet));
                
            });
        }
    }
    public static void HandleAndFill(/*string ConnectionString*/)
    {
        using (TweetContext db = new TweetContext(/*ConnectionString*/))
        {
            IEnumerable<SimplifiedTweet> Tweets = db.Tweets;
            Tweets.AsParallel().ForAll(tweet =>
            {
                CreateTweet.FillTweetSentiment(new Tweet(tweet));
                StateRepository.FillSentiment(new Tweet(tweet));
            });
            Parallel.ForEach(Tweets.Take(3000), tweet =>
            {
                GMapDraw.DrawMarkers(new Tweet(tweet));

            });
        }

    }
}

