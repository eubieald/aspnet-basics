using ProjectApiBasics.Data;

namespace ProjectApiBasics.Repositories
{
    public interface IGamesRepo
    {
        Task DeleteGame(Game _game);
        Task<List<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task<Game> GetByName(string name);
        Task InsertGameAsync(Game game);
        Task UpdateGame(Game _game);
    }
}