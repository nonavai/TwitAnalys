using System.Diagnostics;
using GMap.NET;
using Microsoft.Extensions.DependencyInjection;
using TwitAnalys;
using TwitAnalys.DataLayer;
using TwitAnalys.DB;
using TwitAnalys.Models;
using TwitAnalys.View;



public class Client
{
    public static async Task Main()
    {
        Task task1 =  StateRepository.CreateRepository("C:\\rider\\c#projects\\files\\states.json");
        Task task3 = SentimentRepository.CreateRepository("C:\\rider\\c#projects\\files\\sentiments.csv");
        Task.WaitAll(task1, task3);
        new TweetHandler();
        await CreateTweet.CreateRepository("C:\\rider\\c#projects\\files\\family_tweets2014.txt");
        Task.WaitAll(CreateTweet.Tasks.ToArray());
        new asd();
    }
}

public class asd
{
    static TweetContext db = new ();
    public asd()
    {
        Thread writeThread = new Thread(WriteDat);
        writeThread.Priority = ThreadPriority.BelowNormal;
        writeThread.Start();
    }
    private void WriteDat()
    {
        Thread.Sleep(1000);
        StateRepository.FillColor();
        Seed.chek.Clear();
        Seed.chek.Add(false);
        ApplicationConfiguration.Initialize();
        Application.Run(new TwitAnalys.View.GMap());
    }
}