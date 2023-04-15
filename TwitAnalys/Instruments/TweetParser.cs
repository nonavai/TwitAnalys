using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using GMap.NET;
using TwitAnalys.DataLayer;
using TwitAnalys.Models;

namespace TwitAnalys.Instruments;

public class TweetParser
{
    
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String[]")]
    public static Tweet? Parse(string text)
    {
        string[] elements = text.Split('\t');
        if (elements.Length == 4)
        {
            string[] coordinates = elements[0].Replace("[", "").Replace("]", "").Split(", ");
            PointLatLng newPoint = new PointLatLng(Convert.ToDouble(coordinates[0].Replace(".", ",")),
                Convert.ToDouble(coordinates[1].Replace(".", ",")));
            return new Tweet(newPoint, elements[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
        
        return null;
    }
    /*public static SimplifiedTweet? ParseSimplified(string text)
    {
        string[] elements = text.Split('\t');
        if (elements.Length == 4)
        {
            string[] coordinates = elements[0].Replace("[", "").Replace("]", "").Split(", ");
            //PointLatLng newPoint = new PointLatLng(Convert.ToDouble(coordinates[0].Replace(".", ",")),
              //  Convert.ToDouble(coordinates[1].Replace(".", ",")));
            return new SimplifiedTweet(Convert.ToDouble(coordinates[0].Replace(".", ",")),
                Convert.ToDouble(coordinates[1].Replace(".", ",")), elements[^1]);
        }
        
        return null;
    }*/
    
    
}