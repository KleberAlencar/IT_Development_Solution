using Users.Domain.Shared.Exceptions;

namespace Users.Domain.Users.ValueObjects.Exceptions;

public sealed class InvalidNameException(string message) 
    : DomainException(message);