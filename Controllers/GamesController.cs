using Microsoft.AspNetCore.Mvc;
using ProjectApiBasics.Data;
using ProjectApiBasics.DBContext;
using ProjectApiBasics.DTOs;
using ProjectApiBasics.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApiBasics.Controllers;

[Route("api/[controller]")] // Needed to specify that this class will act as an API controller path
[ApiController]
public class GamesController(IGamesRepo gamesRepo) : ControllerBase
{
    public IGamesRepo gamesRepo = gamesRepo;
        
    // GET: api/<GamesController>
    [HttpGet]
    public async Task<IActionResult> Get() // IActionResult is a generic return type
    {
        //return new string[] { "value1", "value2" };
        var games = await gamesRepo.GetAll();
        return Ok(games.Select(game => game.ToDto()));
    }

    // GET api/<GamesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        //var game = Games.Find(g => g.Id == id);
        var game = await gamesRepo.GetById(id);
        if (game == null)
        {
            return NotFound();
        }

        return Ok(game.ToDto());
    }

    // POST api/<GamesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateGameDtos value)
    {
        //var game = Games.Find(g => g.Id == value.Id);
        var game = await gamesRepo.GetByName(value.Name);
        if (game != null) return BadRequest(new {message="Name for the game already exists."});

        await gamesRepo.InsertGameAsync(new Game
        {
            Name = value.Name,
            Description = value.Description,
            Studio = value.Studio,
            Review = 0f,
            DateTimeCreated = DateTime.Now,
        });
        return NoContent();
    }

    // PUT api/<GamesController>/5s
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateGameDtos value)
    {
        var game = await gamesRepo.GetById(id);
        if (game == null) return NotFound();

        game.Review = value.Review;
        game.Studio = value.Studio;
        game.Name = value.Name;
        game.Description = value.Description;

        await gamesRepo.UpdateGame(game);
        return NoContent();
    }

    // DELETE api/<GamesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var game = await gamesRepo.GetById(id);
        if (game == null) return NotFound();
        await gamesRepo.DeleteGame(game);
        return NoContent();
    }
}
