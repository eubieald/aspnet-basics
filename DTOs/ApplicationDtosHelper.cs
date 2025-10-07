using ProjectApiBasics.Data;

namespace ProjectApiBasics.DTOs;

public static class ApplicationDtosHelper
{
    public static ApplicationDtos ToDto(this Application application)
    {
        return new ApplicationDtos(application.Id, application.Name, application.Description);
    }
}
