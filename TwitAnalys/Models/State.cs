using GMap.NET.WindowsForms;

namespace TwitAnalys.Models;
public class State
{
    public string Name;
    public List<GMapPolygon> Polygons;
    public int TweetsCount = 0;
    public int NonSentimentTweets = 0;
    public double GlobalSentiment = 0;
    
    public State(string name, List<GMapPolygon> polygons)
    {
        Name = name;
        Polygons = polygons;
    }
    
    public override string ToString()
    {
        return String.Format($"state initials: {Name}. It's Global Sentiment: {GlobalSentiment}");
    }
}


