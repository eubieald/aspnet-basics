using MongoDB.Driver;
using ProjectApiBasics.Data;
using ProjectApiBasics.DBContext;

namespace ProjectApiBasics.Repositories
{
    public class GamesRepo : IGamesRepo
    {
        private MongoDbContext _dbContext;

        public GamesRepo(MongoDbContext context)
        {
            this._dbContext = context;
        }

        /// <summary>
        /// Retrieve all games data from the Database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Game>> GetAll() => await (await this._dbContext.Game.FindAsync(g => true)).ToListAsync();

        public async Task<Game> GetById(Guid id)
        {
            return await (await this._dbContext.Game.FindAsync(game => game.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<Game> GetByName(string name)
        {
            return await (await this._dbContext.Game.FindAsync(game => game.Name.Equals(name))).FirstOrDefaultAsync();
        }

        public async Task InsertGameAsync(Game game)
        {
            await this._dbContext.Game.InsertOneAsync(game);
        }

        public async Task UpdateGame(Game _game)
        {
            await this._dbContext.Game.ReplaceOneAsync(game => game.Id == _game.Id, _game);
        }

        public async Task DeleteGame(Game _game)
        {
            await this._dbContext.Game.DeleteOneAsync(game => game.Id == _game.Id);
        }
    }
}
