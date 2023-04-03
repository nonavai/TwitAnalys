using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TwitAnalys.DataLayer;

namespace TwitAnalys.View;

public class GMapDraw
{
    public static void DrawPolygons(GMapOverlay overlay)
    {
        
        Parallel.ForEach(StateRepository.States, state =>
        {
            Parallel.For(0, state.Polygons.Count, i =>
            {
                overlay.Polygons.Add(state.Polygons[i]);
            });
        });
    }

    public static void DrawMarkers(GMapOverlay overlay)
    {
        int multiplier = 1;
        if (TweetRepository.Tweets.Count > 3000)
        {
            multiplier = TweetRepository.Tweets.Count / 3000;
            /*Parallel.For(0, 1000, i =>*/for(int i = 0; i < 3000; i++)
            {
                if (TweetRepository.Tweets[i*multiplier].GetSentiment() > 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.green_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() < 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.red_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() == 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.gray_small));
            }/*);*/
        }
        else
        {
            /*Parallel.For(0, TweetRepository.Tweets.Count, i =>*/ for(int i = 0; i < TweetRepository.Tweets.Count; i++)
            {
                if (TweetRepository.Tweets[i*multiplier].GetSentiment() > 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.green_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() < 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.red_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() == 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.gray_small));
            }/*);*/
        }
        
    }
}