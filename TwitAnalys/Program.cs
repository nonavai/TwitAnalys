using System.Diagnostics;
using TwitAnalys.DataLayer;
using TwitAnalys.View;

public class Client
{

    public static async Task Main()
    {
        var sw = new Stopwatch();
        
        sw.Start();
        Task task1 =  StateRepository.CreateRepository("C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\states.json");
        Task task2 = TweetRepository.CreateRepository("C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\family_tweets2014.txt");
        Task task3 =
            SentimentRepository.CreateRepository("C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\sentiments.csv");
        Task.WaitAll(task1, task2, task3);
        //GC.Collect();
        Console.WriteLine(sw.Elapsed);
        TweetRepository.FillTweetSentiment();
        Console.WriteLine(sw.Elapsed);
        StateRepository.FillSentiment();
        StateRepository.FillColor();
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
        ApplicationConfiguration.Initialize();
        GC.Collect();
        Application.Run(new TwitAnalys.View.GMap());
    }


} 