using System.Diagnostics;
using TwitAnalys.DataLayer;
using TwitAnalys.View;

public class Client
{

    public static async Task Main()
    {
        Task task1 =  StateRepository.CreateRepository("C:\\rider\\c#projects\\files\\states.json");
        //Task task2 = TweetRepository.CreateRepository("C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\family_tweets2014.txt");
        Task task3 =
            SentimentRepository.CreateRepository("C:\\rider\\c#projects\\files\\sentiments.csv");
        Task.WaitAll(task1, task3);
        await TweetRepository.CreateRepository("C:\\rider\\c#projects\\files\\family_tweets2014.txt");
        //GC.Collect();
        
  /*      TweetRepository.FillTweetSentiment();
        Console.WriteLine(sw.Elapsed);
        StateRepository.FillSentiment();*/
        StateRepository.FillColor();
        ApplicationConfiguration.Initialize();
        GC.Collect();
        Application.Run(new TwitAnalys.View.GMap());
    }


} 