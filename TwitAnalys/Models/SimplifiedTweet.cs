using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GMap.NET;
using Microsoft.IdentityModel.Tokens;

namespace TwitAnalys.Models;

public class SimplifiedTweet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SimplifiedTweetId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string TweetText { get; set; }
    public double Sentiment { get; set; }
    public string? State { get; set; }
    
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

    private string[] splited;
    public string[] Splited
    {
        get
        {
            if (splited.IsNullOrEmpty()) splited = StrSplit();
            return splited;
        }
    }

    public PointLatLng GetCoordinate() => new (Latitude, Longitude);
    public string[] StrSplit() => TweetText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    public void SetSentiment(double value) => Sentiment = value;
    public double GetSentiment() => Sentiment;
    public string? GetStateName() => State;
    public void SetState(string stateName) => State = stateName;
    public void GetState(string state) => State = state;
}