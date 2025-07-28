using Users.Domain.Users.Entities;
using Users.Domain.Shared.Repositories.Interfaces;

namespace Users.Application.Users.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}