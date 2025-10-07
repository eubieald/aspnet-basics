using ProjectApiBasics.Data;

namespace ProjectApiBasics.Repositories
{
    public interface IApplicationRepo
    {
        Task DeleteGame(Application game);
        Task<List<Application>> GetAll();
        Task<Application?> GetById(int id);
        Task<Application?> GetByName(string name);
        Task InsertGameAsync(Application game);
        Task SaveGame(Application game);
    }
}