using Microsoft.EntityFrameworkCore;
using TwitAnalys.Models;

namespace TwitAnalys.DB;

public class TweetContext : DbContext
{
    public DbSet<SimplifiedTweet> Tweets { get; set; }

    public string DbPath = $"Server=(localdb)\\mssqllocaldb;Database=TweetDb;Trusted_Connection=True;";

    /*public TweetContext(string ConnectionString)
    {
        //Database.EnsureCreated();
        DbPath = ConnectionString;
    }*/
    public TweetContext()
    {
        //Database.EnsureCreated();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(DbPath);
}