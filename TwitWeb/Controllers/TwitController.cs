using Microsoft.AspNetCore.Mvc;
using TwitAnalys.DB;
using TwitAnalys.Models;

namespace TwitWeb.Controllers;

public class TwitController : ControllerBase
{
    public static readonly TweetContext db = new ();
    
    private readonly ILogger<TwitController> _logger;
    
    public TwitController(ILogger<TwitController> logger)
    {
        _logger = logger;
    }
    
    // GET: api/twit
    [HttpGet("get-some-tweets")]
    public ActionResult<List<SimplifiedTweet>> GetSomeTweets(int take, int skip)
    {
        IEnumerable<SimplifiedTweet> tweets = db.Tweets.Skip(skip).Take(take);
        return Ok(tweets.ToList());
    }
    
    // GET: api/twit/5
    [HttpGet("{id}", Name = "GetTwit")]
    public ActionResult<SimplifiedTweet> GetTwit(int id)
    {
        var tweet = db.Tweets.Find(id);
        if (tweet == null)
        {
            return NotFound();
        }
        return Ok(tweet);
    }
    
    // POST: api/twit
    [HttpPost]
    public ActionResult<SimplifiedTweet> CreateTwit(SimplifiedTweet tweet)
    {
        db.Tweets.Add(tweet);
        db.SaveChanges();
        return CreatedAtRoute("GetTwit", new { id = tweet.SimplifiedTweetId }, tweet);
    }
    
    // PUT: api/twit/5
    [HttpPut("{id}")]
    public ActionResult<SimplifiedTweet> UpdateTwit(int id, SimplifiedTweet tweet)
    {
        var tweetToUpdate = db.Tweets.Find(id);
        if (tweetToUpdate == null)
        {
            return NotFound();
        }
        tweetToUpdate.Latitude = tweet.Latitude;
        tweetToUpdate.Longitude = tweet.Longitude;
        tweetToUpdate.TweetText = tweet.TweetText;
        tweetToUpdate.Sentiment = tweet.Sentiment;
        tweetToUpdate.State = tweet.State;
        db.SaveChanges();
        return Ok(tweetToUpdate);
    }
    
    // DELETE: api/twit/5
    [HttpDelete("{id}")]
    public ActionResult DeleteTwit(int id)
    {
        var tweet = db.Tweets.Find(id);
        if (tweet == null)
        {
            return NotFound();
        }
        db.Tweets.Remove(tweet);
        db.SaveChanges();
        return Ok(tweet);
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateTweet(int id, [FromBody] SimplifiedTweet tweet)
    {
        SimplifiedTweet tweetToUpdate = db.Tweets.Find(id);//FirstOrDefault(t => t.SimplifiedTweetId == id);

        if (tweetToUpdate == null)
        {
            return NotFound();
        }
        
        tweetToUpdate.Sentiment = tweet.Sentiment;
        tweetToUpdate.TweetText = tweet.TweetText;

        db.SaveChanges();

        return Ok(tweetToUpdate);
    }

}
    
    /*[HttpGet]
        public ActionResult<IEnumerable<SimplifiedTweet>> GetAllTweets()
        {
            //_logger.Log(LogLevel.Information, "all");
            IEnumerable<SimplifiedTweet> Tweets = db.Tweets;
            return Ok(Tweets);
        }*/
    
