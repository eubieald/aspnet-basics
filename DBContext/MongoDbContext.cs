using MongoDB.Driver;
using ProjectApiBasics.Data;

namespace ProjectApiBasics.DBContext
{
    public class MongoDbContext
    {
        private IMongoDatabase database;
        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            database = client.GetDatabase("games");
        }

        public IMongoCollection<Game> Game => database.GetCollection<Game>("gamesCollection");
    }
}
