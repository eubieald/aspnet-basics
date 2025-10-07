using Microsoft.EntityFrameworkCore;
using ProjectApiBasics.Data;
using ProjectApiBasics.DBContext;

namespace ProjectApiBasics.Repositories;
public class ApplicationRepo : IApplicationRepo
{
    private ApplicationDBContext _dbContext;

    public ApplicationRepo(ApplicationDBContext context)
    {
        this._dbContext = context;
    }

    public async Task<List<Application>> GetAll() => await this._dbContext.Games.ToListAsync();

    public async Task<Application?> GetById(int id)
    {
        //return await (await this._dbContext.Games.FindAsync(game => game.Id == id)).FirstOrDefaultAsync();
        return await this._dbContext.Games.FindAsync(id);
    }

    public async Task<Application?> GetByName(string name)
    {
        return await this._dbContext.Games.FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task InsertGameAsync(Application game)
    {
        await this._dbContext.Games.AddAsync(game);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task SaveGame(Application game)
    {
        await this._dbContext.SaveChangesAsync();
    }

    public async Task DeleteGame(Application game)
    {
        this._dbContext.Games.Remove(game);
        await this._dbContext.SaveChangesAsync();
    }
}
