using System.Text;
using ABI.Windows.ApplicationModel.VoiceCommands;
using GMap.NET;
using TwitAnalys.DataLayer;

namespace TwitAnalys.Models;

public class SimplifiedTweet
{
    public int SimplifiedTweetId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string TweetText { get; set; }

    
    public double Sentiment { get; set; }
    
    public string? State { get; set; }

    public SimplifiedTweet(Tweet tweet)
    {
        Longitude = tweet.Placemnt.Lng;
        Latitude = tweet.Placemnt.Lat;
        StringBuilder sb = new StringBuilder(tweet.TweetText[0]);
        for (int i = 1; i < tweet.TweetText.Length; i++)
        {
            sb.Append(tweet.TweetText[i] + " ");
        }
        sb.Remove(sb.Length - 1, 1);
        TweetText = sb.ToString();
        sb.Clear();
        Sentiment = tweet.GetSentiment();
        State = tweet.GetStateName();
    }
    public SimplifiedTweet(double latitude, double longitude, string tweetText)
    {
        Latitude = latitude;
        Longitude = longitude;
        TweetText = tweetText;
    }
    public SimplifiedTweet(double latitude, double longitude, string tweetText, double sentiment)
    {
        Latitude = latitude;
        Longitude = longitude;
        TweetText = tweetText;
        Sentiment = sentiment;
    }
    public SimplifiedTweet(double latitude, double longitude, string tweetText, double sentiment, string? state)
    {
        Latitude = latitude;
        Longitude = longitude;
        TweetText = tweetText;
        Sentiment = sentiment;
        State = state;
    }
    public SimplifiedTweet()
    {
        
    }

    public void SetSentiment(double value) => Sentiment = value;

    public double GetSentiment() => Sentiment;
    public string? GetStateName() => State;
    public void SetState(string stateName) => State = stateName;

    

    public void GetState(string state) => State = state;
}