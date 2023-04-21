using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TwitAnalys.DataLayer;
using TwitAnalys.Models;

namespace TwitAnalys.View;

public static class GMapDraw
{
    public static GMapOverlay Overlay = new ("map");
    public static void DrawPolygons()
    {
        
        Parallel.ForEach(StateRepository.States, state =>
        {
            Parallel.For(0, state.Polygons.Count, i =>
            {
                Overlay.Polygons.Add(state.Polygons[i]);
            });
        });
    }
    public static void DrawMarkers(SimplifiedTweet tweet)
    {
        if (tweet.GetSentiment() > 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.GetCoordinate(), GMarkerGoogleType.green_small));
        else if (tweet.GetSentiment() < 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.GetCoordinate(), GMarkerGoogleType.red_small));
        else if (tweet.GetSentiment() == 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.GetCoordinate(), GMarkerGoogleType.gray_small));
    }
}