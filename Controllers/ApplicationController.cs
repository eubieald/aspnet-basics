using Microsoft.AspNetCore.Mvc;
using ProjectApiBasics.Data;
using ProjectApiBasics.DTOs;
using ProjectApiBasics.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApiBasics.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController(IApplicationRepo applicationRepo) : ControllerBase
{
    public IApplicationRepo applicationRepo = applicationRepo;

    // GET: api/<GamesController>
    [HttpGet]
    public async Task<IActionResult> Get() // IActionResult is a generic return type
    {
        var games = await applicationRepo.GetAll();
        return Ok(games.Select(game => game.ToDto()));
    }

    // GET api/<ApplicationControllerr>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var game = await applicationRepo.GetById(id);
        if (game == null)
        {
            return NotFound();
        }

        return Ok(game.ToDto());
    }

    // POST api/<ApplicationControllerr>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateApplicationDtos value)
    {
        var game = await applicationRepo.GetByName(value.Name);
        if (game != null) return BadRequest(new { message = "Name for the game already exists." });

        await applicationRepo.InsertGameAsync(new Application
        {
            Name = value.Name,
            Description = value.Description,
            Studio = value.Studio,
            Review = 0f,
            DateTimeCreated = DateTime.Now,
        });
        return NoContent();
    }

    // PUT api/<ApplicationControllerr>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateApplicationDtos value)
    {
        var game = await applicationRepo.GetById(id);
        if (game == null) return NotFound();
        game.Name = value.Name;
        game.Review = value.Review;
        game.Studio = value.Studio;
        game.Description = value.Description;

        await applicationRepo.SaveGame(game);
        return NoContent();
    }

    // DELETE api/<GamesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await applicationRepo.GetById(id);
        if (game == null) return NotFound();
        await applicationRepo.DeleteGame(game);
        return NoContent();
    }
}
