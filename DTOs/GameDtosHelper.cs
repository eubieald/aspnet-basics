using ProjectApiBasics.Data;

namespace ProjectApiBasics.DTOs;

public static class GameDtosHelper
{
    public static GameDtos ToDto(this Game game)
    {
        return new GameDtos(game.Id, game.Name, game.Description);
    }
}
