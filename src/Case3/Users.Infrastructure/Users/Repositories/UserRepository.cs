using Dapper;
using Users.Domain.Users.Entities;
using Users.Infrastructure.Users.Scripts;
using Users.Infrastructure.Database.Interfaces;
using Users.Application.Users.Repositories.Interfaces;

namespace Users.Infrastructure.Users.Repositories;

public class UserRepository(IDbConnectionFactory dbConnectionFactory) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);
        var user = await connection.QuerySingleOrDefaultAsync<User>(
            new CommandDefinition(UserScript.GetById, new { id }, cancellationToken: cancellationToken));
        return user ?? null;
    }
}