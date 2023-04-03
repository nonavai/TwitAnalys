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

    public void SetSentiment(double value)
    {
        Sentiment = value;
    }

    public double GetSentiment()
    {
        return Sentiment;
    }

    public void SetState(string stateName)
    {
        State = stateName;
    }


    public override string ToString()
    {
        return string.Format($"Latitude : {Placemnt.Lat}, Longitude : {Placemnt.Lng}, Tweet : {TweetText}");
    }
}