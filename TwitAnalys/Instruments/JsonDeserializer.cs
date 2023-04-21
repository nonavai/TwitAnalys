using System.Text;
using System.Text.Json;
using GMap.NET;
using GMap.NET.WindowsForms;
using TwitAnalys.Models;


namespace TwitAnalys.Instruments;

public class JsonDeserializer
{
    public static List<State> Deserialize(string json)
    {
        
        ReadOnlySpan<byte> jsonUtf8 = Encoding.UTF8.GetBytes(json);
        var reader = new Utf8JsonReader(jsonUtf8);
        string currName = String.Empty;
        double longitude = 0;
        bool firstNum = true;
        bool hasPolygons = false;
        List<State> states = new List<State>();
        List<GMapPolygon> polygons = new List<GMapPolygon>();
        List<PointLatLng> points = new List<PointLatLng>();
        int arrCount = 0;
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName:
                    if (polygons.Count != 0 || points.Count != 0)
                    {
                        if (polygons.Count != 0) states.Add(new State(currName, polygons));
                        else
                        {
                            polygons.Add(new GMapPolygon(points, currName + "Polygon"));
                            states.Add(new State(currName, polygons));
                        }

                    }

                    currName = reader.GetString();
                    polygons = new List<GMapPolygon>();
                    points = new List<PointLatLng>();
                    hasPolygons = false;
                    break;
                case JsonTokenType.StartArray:
                    arrCount++;
                    if (arrCount == 4) hasPolygons = true;
                    break;
                case JsonTokenType.Number:
                    if (firstNum) longitude = reader.GetDouble();
                    else
                    {
                        points.Add(new PointLatLng( reader.GetDouble(), longitude));
                    }

                    firstNum = !firstNum;
                    break;
                case JsonTokenType.EndArray:
                    arrCount--;
                    if (hasPolygons && arrCount == 2)
                    {
                        polygons.Add(new GMapPolygon(points, currName + "Polygon"));
                        points = new List<PointLatLng>();
                    }

                    break;
                
            }
        }
        if (polygons.Count != 0) states.Add(new State(currName, polygons));
        else
        {
            polygons.Add(new GMapPolygon(points, currName + "Polygon"));
            states.Add(new State(currName, polygons));
        }

        return states;
    }
}
