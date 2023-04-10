using GMap.NET;

namespace TwitAnalys.Models;

public class Tweet
{
    public PointLatLng Placemnt;
    public string[] TweetText;
    private double Sentiment = 0;
    private string? State = null;

    public Tweet(PointLatLng placemnt, string[] tweetText)
    {
        Placemnt = placemnt;
        TweetText = tweetText;
    }

    public Tweet(SimplifiedTweet tweet)
    {
        Placemnt.Lat = tweet.Latitude;
        Placemnt.Lng = tweet.Longitude;
        TweetText = tweet.TweetText.Split(' ');
        Sentiment = tweet.GetSentiment();
        State = tweet.GetStateName();
    }

    public void SetSentiment(double value) => Sentiment = value;
    public void SetState(string stateName) => State = stateName;
    public double GetSentiment() => Sentiment;
    public string? GetStateName() => State; 


    public override string ToString()
    {
        return string.Format($"Latitude : {Placemnt.Lat}, Longitude : {Placemnt.Lng}, Tweet : {TweetText}");
    }
}