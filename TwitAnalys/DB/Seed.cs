using System.Collections.Concurrent;
using TwitAnalys.Models;

namespace TwitAnalys.DB
{
    public class Seed
    {
        private static TweetContext db = new ();
        public static ConcurrentBag<bool> chek = new() {true};
        ConcurrentQueue<SimplifiedTweet> queue = new ();

        public Seed()
        {
            Thread writeThread = new Thread(WriteData);
            writeThread.Start();
        }
        
        public void WriteData()
        {
            List<SimplifiedTweet> objectsToSave = new List<SimplifiedTweet>();

            while (chek.TryPeek(out bool obj) || queue.Count > 100000)
            {
                while (queue.TryDequeue(out SimplifiedTweet result))
                {
                    if (!result.Latitude.Equals(0)) //could be simplified 
                    {
                        objectsToSave.Add(result);
                    }

                    if (objectsToSave.Count >= 100000)
                    {
                        db.AddRange(objectsToSave);
                        db.SaveChanges();
                        objectsToSave.Clear();
                    }
                }
                if (!obj && queue.Count == 0)break;
            }

            while  (objectsToSave.Count > 0)
            {
                db.AddRange(objectsToSave);
                db.SaveChanges();
                objectsToSave.Clear();
            }
        }


        public void Seeding(SimplifiedTweet tweet) => queue.Enqueue(tweet);

        public static void Save() => db.SaveChanges();
    }
}