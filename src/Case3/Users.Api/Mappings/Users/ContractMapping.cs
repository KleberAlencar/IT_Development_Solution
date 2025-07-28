using Users.Api.Contracts.Users.Responses;

namespace Users.Api.Mappings.Users;

public static class ContractMapping
{
    public static UserResponse MapToResponse(
        this Domain.Users.Entities.User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            FirstName = user.Name.FirstName,
            LastName = user.Name.LastName,
            Email = user.Email
        };
    }
}