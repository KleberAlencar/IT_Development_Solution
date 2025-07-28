using Users.Domain.Users.Entities;
using Users.Domain.Shared.Results;
using Users.Application.Users.Services.Interfaces;
using Users.Application.Users.Repositories.Interfaces;

namespace Users.Application.Users.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Result<User?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetByIdAsync(id, cancellationToken);
    }
}