using Users.Domain.Shared.Exceptions;

namespace Users.Domain.Users.ValueObjects.Exceptions;

public sealed class InvalidLastNameLengthException(string message)
    : DomainException(message);