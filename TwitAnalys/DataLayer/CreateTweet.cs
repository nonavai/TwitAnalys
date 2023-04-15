using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TwitAnalys.Instruments;
using TwitAnalys.Models;
using TwitAnalys.View;

namespace TwitAnalys.DataLayer;

public class CreateTweet
{
    //public static List<Tweet> Tweets = new ();
    
    public static async Task CreateRepository(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                Tweet? tweet = TweetParser.Parse(reader.ReadLine());
                if (tweet != null) TweetHandler.HandleAndCreate(tweet);
            }
        }
    }

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    public static void FillTweetSentiment(Tweet tweet)
    {
        Dictionary<string, double> sentiments = SentimentRepository.Sentiment;
        /*Parallel.ForEach(Tweets, tweet =>
        {*/
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < tweet.TweetText.Length - 4; i++)
        {
            int q = 4;
            
            while (q != 0)
            {
               
                for (int j = 0; j < q; j++)
                {
                    sb.Append(tweet.TweetText[i + j] + " ");
                }

                sb.Remove(sb.Length - 1, 1);
                if (sentiments.ContainsKey(sb.ToString()))
                {
                    tweet.SetSentiment(tweet.GetSentiment() + sentiments[sb.ToString()]);
                    i += q;
                    sb.Clear();
                    break;
                }
                sb.Clear();
                q--;
            }
        }
        StateRepository.FillSentiment(tweet);
    }
}