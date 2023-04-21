using System.Diagnostics.CodeAnalysis;
using TwitAnalys.Models;

namespace TwitAnalys.Instruments;

public class TweetParser
{
    
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String[]")]

    public static SimplifiedTweet? ParseSimplified(string text)
    {
        string[] elements = text.Split('\t');
        if (elements.Length == 4)
        {
            string[] coordinates = elements[0].Replace("[", "").Replace("]", "").Split(", ");
            return new SimplifiedTweet(Convert.ToDouble(coordinates[0].Replace(".", ",")),
                Convert.ToDouble(coordinates[1].Replace(".", ",")), elements[^1]);
        }
        
        return null;
    }
    
    
}