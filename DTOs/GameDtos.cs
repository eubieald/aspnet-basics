namespace ProjectApiBasics.DTOs;
public record GameDtos(Guid Id, string Name, string Description);
public record CreateGameDtos(string Name, string Description, string Studio);
public record UpdateGameDtos(string Name, string Description, float Review, string Studio);
