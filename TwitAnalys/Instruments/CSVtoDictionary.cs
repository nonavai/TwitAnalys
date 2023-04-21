
namespace TwitAnalys.Instruments;

public class CSVtoDictionary
{
    public static Dictionary<string, double> ConvertCsVtoDictionary(string text)
    {
        Dictionary<string, double> sentiment = new Dictionary<string, double>();
        string[] aaa = text.Split('\n');
        foreach (var mmm in aaa)
        {
            string[] elems = mmm.Split(',');
            sentiment.Add(elems[0], Convert.ToDouble(elems[1].Replace('.', ',')));
        }
        


        return sentiment;
    }
}