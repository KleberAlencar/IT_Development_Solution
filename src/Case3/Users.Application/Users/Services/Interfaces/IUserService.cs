using Users.Domain.Shared.Results;
using Users.Domain.Users.Entities;

namespace Users.Application.Users.Services.Interfaces;

public interface IUserService
{
    Task<Result<User?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}