using System.Diagnostics.CodeAnalysis;
using System.Text;
using TwitAnalys.Instruments;
using TwitAnalys.Models;

namespace TwitAnalys.DataLayer;

public class CreateTweet
{
    public static List<Task> Tasks= new (); 
    public static async Task CreateRepository(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                SimplifiedTweet? tweet = TweetParser.ParseSimplified(reader.ReadLine());
                if (tweet != null) Tasks.Add( Task.Run(() => TweetHandler.HandleAndCreate(tweet)));
            }
        }
    }

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    
    public static void FillTweetSentiment(SimplifiedTweet tweet)
    {
        Dictionary<string, double> sentiments = SentimentRepository.Sentiment;
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < tweet.Splited.Length - 4; i++)
        {
            int q = 4;
            
            while (q != 0)
            {
               
                for (int j = 0; j < q; j++)
                {
                    sb.Append(tweet.Splited[i + j] + " ");
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
    }
}