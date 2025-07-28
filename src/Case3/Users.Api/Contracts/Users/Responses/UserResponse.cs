namespace Users.Api.Contracts.Users.Responses;

public record UserResponse
{
    public required int Id { get; init; }
    
    public required string FirstName { get; init; }
    
    public required string LastName { get; init; }
    
    public required string Email { get; init; }
}