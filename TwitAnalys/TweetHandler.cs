using TwitAnalys.DataLayer;
using TwitAnalys.DB;
using TwitAnalys.Models;
using TwitAnalys.View;

namespace TwitAnalys;

public class TweetHandler
{
    public static int count = 0;
    private static Seed SeedController;
    
    
    public TweetHandler()
    {
        SeedController = new Seed();
        
    }
    public async static Task HandleAndCreate(SimplifiedTweet tweet)
    {
        
        CreateTweet.FillTweetSentiment(tweet);
        if (count < 3000)
        {
            lock (SeedController)
            {
                count++;
                if (count < 3000)GMapDraw.DrawMarkers(tweet);
            }
        }

        StateRepository.FillSentiment(tweet);
        SeedController.Seeding(tweet);
    }

    public static void Handle()
    {
        using (TweetContext db = new TweetContext())
        {
            IEnumerable<SimplifiedTweet> Tweets = db.Tweets;
            Tweets.AsParallel().ForAll(tweet =>
            {
                StateRepository.FillSentiment(tweet);
            });
            Parallel.ForEach(Tweets.Take(3000), tweet =>
            {
                GMapDraw.DrawMarkers(tweet);
                
            });
        }
    }
    public static void HandleAndFill()
    {
        using (TweetContext db = new TweetContext())
        {
            IEnumerable<SimplifiedTweet> Tweets = db.Tweets;
            Tweets.AsParallel().ForAll(tweet =>
            {
                CreateTweet.FillTweetSentiment(tweet);
                StateRepository.FillSentiment(tweet);
            });
            Parallel.ForEach(Tweets.Take(3000), tweet =>
            {
                GMapDraw.DrawMarkers(tweet);

            });
        }

    }
}

