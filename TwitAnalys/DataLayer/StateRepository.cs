using TwitAnalys.Instruments;
using TwitAnalys.Models;

namespace TwitAnalys.DataLayer;

public class StateRepository
{
    public static List<State> States;
    public static async Task CreateRepository(string json)
    {
        StreamReader reader = new StreamReader(json);
        States =JsonDeserializer.Deserialize( await reader.ReadToEndAsync());
    }
    
    public static void FillColor()
     {
        Parallel.ForEach(States, state =>
        {
            Parallel.For(0, state.Polygons.Count, i =>
            {
                SolidBrush solidBrush;
                if (state.GlobalSentiment / (state.TweetsCount - state.NonSentimentTweets) >= 0)
                {
                    if (state.GlobalSentiment / (state.TweetsCount - state.NonSentimentTweets) < 0.6)
                    {
                        solidBrush = new(Color.FromArgb(((state.TweetsCount-state.NonSentimentTweets) / state.TweetsCount)*100 +155 ,
                           0 ,Convert.ToInt32(state.GlobalSentiment / (state.TweetsCount - state.NonSentimentTweets)*425), 0));
                    }
                    else
                    {
                        solidBrush = new(Color.FromArgb(((state.TweetsCount-state.NonSentimentTweets) / state.TweetsCount)*100 +155, 255, 0, 0));
                    }
                }
                else
                {
                    if (state.GlobalSentiment / (state.TweetsCount - state.NonSentimentTweets) > -0.6)
                    {
                        solidBrush = new(Color.FromArgb(
                            ((state.TweetsCount-state.NonSentimentTweets) / state.TweetsCount)*100 +155,
                            Convert.ToInt32(state.GlobalSentiment / (state.TweetsCount - state.NonSentimentTweets)*-425) ,0 , 0));
                    }
                    else if (state.TweetsCount-state.NonSentimentTweets > 0 )
                    {
                        solidBrush = new(Color.FromArgb(((state.TweetsCount-state.NonSentimentTweets) / state.TweetsCount)*100 +155, 0, 255, 0));
                    }
                    else
                    {
                        solidBrush = new (Color.FromArgb(155, 155, 155, 155));
                    }

                }

                state.Polygons[i].Fill = solidBrush;
                state.Polygons[i].Stroke = new Pen(Color.Blue, 1);
            });
        });
     }

    public static void FillSentiment()
    {
       

        //foreach (var state in StateRepository.States)
        Parallel.ForEach(States, state =>
        {
            Parallel.For(0, state.Polygons.Count, i =>
            {
                foreach (var tweet in TweetRepository.Tweets)
                {
                    if (state.Polygons[i].IsInside(tweet.Placemnt))
                    {
                        state.GlobalSentiment += tweet.GetSentiment();
                        state.TweetsCount++;
                        if (tweet.GetSentiment() == 0) state.NonSentimentTweets++;
                    }
                }

            });
        });
    } 
    public List<State> GetStates()
    {
        return States;
    }
}
//"C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\states.json"