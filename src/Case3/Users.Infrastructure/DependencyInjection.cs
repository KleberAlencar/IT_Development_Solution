using Users.Infrastructure.Database;
using Users.Infrastructure.Users.Repositories;
using Users.Infrastructure.Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Users.Repositories.Interfaces;

namespace Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}