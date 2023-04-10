using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TwitAnalys.DataLayer;
using TwitAnalys.Models;

namespace TwitAnalys.View;

public static class GMapDraw
{
    public static GMapOverlay Overlay = new GMapOverlay("map");
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

    /*public static void DrawMarkers(GMapOverlay overlay)
    {
        int multiplier = 1;
        if (TweetRepository.Tweets.Count > 3000)
        {
            multiplier = TweetRepository.Tweets.Count / 3000;
            /*Parallel.For(0, 1000, i =>#1#for(int i = 0; i < 3000; i++)
            {
                if (TweetRepository.Tweets[i*multiplier].GetSentiment() > 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.green_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() < 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.red_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() == 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.gray_small));
            }/*);#1#
        }
        else
        {
            /*Parallel.For(0, TweetRepository.Tweets.Count, i =>#1# for(int i = 0; i < TweetRepository.Tweets.Count; i++)
            {
                if (TweetRepository.Tweets[i*multiplier].GetSentiment() > 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.green_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() < 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.red_small));
                else if (TweetRepository.Tweets[i*multiplier].GetSentiment() == 0) overlay.Markers.Add(new GMarkerGoogle(TweetRepository.Tweets[i*multiplier].Placemnt, GMarkerGoogleType.gray_small));
            }/*);#1#
        }
        
    }*/
    public static void DrawMarkers(Tweet tweet)
    {
        /*Parallel.For(0, 1000, i =>*//*for(int i = 0; i < 3000; i++)*/
            
        if (tweet.GetSentiment() > 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.Placemnt, GMarkerGoogleType.green_small));
        else if (tweet.GetSentiment() < 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.Placemnt, GMarkerGoogleType.red_small));
        else if (tweet.GetSentiment() == 0) Overlay.Markers.Add(new GMarkerGoogle(tweet.Placemnt, GMarkerGoogleType.gray_small));
            /*);*/
        
        
        
    }
}