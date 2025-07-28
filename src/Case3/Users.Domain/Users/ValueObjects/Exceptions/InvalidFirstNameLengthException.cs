using Users.Domain.Shared.Exceptions;

namespace Users.Domain.Users.ValueObjects.Exceptions;

public sealed class InvalidFirstNameLengthException(string message) 
    : DomainException(message);