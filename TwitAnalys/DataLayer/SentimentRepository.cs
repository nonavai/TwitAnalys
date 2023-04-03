using System.Data;
using System.Reflection.Metadata;
using TwitAnalys.Instruments;

namespace TwitAnalys.DataLayer;

public class SentimentRepository
{
    public static Dictionary<string, double> Sentiment;

    public static async Task CreateRepository(string file)
    {
        StreamReader reader = new StreamReader(file);
        Sentiment = CSVtoDictionary.ConvertCsVtoDictionary( await reader.ReadToEndAsync());
    }

    
}