using Users.Domain.Shared.Exceptions;

namespace Users.Domain.Users.ValueObjects.Exceptions;

public class InvalidEmailException(string message)
    : DomainException(message);