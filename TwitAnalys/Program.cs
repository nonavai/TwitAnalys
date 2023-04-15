using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using TwitAnalys;
using TwitAnalys.DataLayer;
using TwitAnalys.DB;
using TwitAnalys.Models;
using TwitAnalys.View;



public class Client
{

    //public delegate void Handler(Tweet tweet);
    
    public static async Task Main()
    {
        Task task1 =  StateRepository.CreateRepository("C:\\rider\\c#projects\\files\\states.json");
        //Task task2 = TweetRepository.CreateRepository("C:\\rider\\c#projects\\TwitAnalys\\TwitAnalys\\files\\family_tweets2014.txt");
        Task task3 = SentimentRepository.CreateRepository("C:\\rider\\c#projects\\files\\sentiments.csv");
        Task.WaitAll(task1, task3);
        new TweetHandler();
        await CreateTweet.CreateRepository("C:\\rider\\c#projects\\files\\tweets2011.txt");
        //Seed.Save();
        StateRepository.FillColor();
        ApplicationConfiguration.Initialize();
        GC.Collect();
        Application.Run(new TwitAnalys.View.GMap());
    }
} 