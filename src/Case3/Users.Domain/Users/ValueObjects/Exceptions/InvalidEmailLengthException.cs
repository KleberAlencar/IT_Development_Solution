using Users.Domain.Shared.Exceptions;

namespace Users.Domain.Users.ValueObjects.Exceptions;

public class InvalidEmailLengthException(string message) 
    : DomainException(message);