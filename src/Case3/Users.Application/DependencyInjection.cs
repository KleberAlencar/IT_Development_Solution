using FluentValidation;
using Users.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Users.Services.Interfaces;

namespace Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Scoped);
        return services;
    } 
}