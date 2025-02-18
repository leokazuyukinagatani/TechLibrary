using Microsoft.Extensions.DependencyInjection;
using TechLibrary.Application.Users.Register;

namespace TechLibrary.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    public static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();

    }
}

