
using System.ComponentModel.DataAnnotations;
using GMap.NET;
using GMap.NET.WindowsForms;
using TwitAnalys.DataLayer;
using TwitAnalys.Models;

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

    


    /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        if (Name == String.Empty || Name != Name.ToUpper() || Name.Length !=2) 
            errors.Add(new ValidationResult("Incorrect State Name"));
        return errors;
    }*/

    public override string ToString()
    {
        return String.Format($"state initials: {Name}. It's Global Sentiment: {GlobalSentiment}");
    }
}


