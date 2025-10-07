namespace ProjectApiBasics.DTOs;
public record ApplicationDtos(int Id, string Name, string Description);
public record CreateApplicationDtos(string Name, string Description, string Studio);
public record UpdateApplicationDtos(string Name, string Description, float Review, string Studio);
