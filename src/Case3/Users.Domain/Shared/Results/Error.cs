﻿namespace Users.Domain.Shared.Results;

public record Error(string Code, string Message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Item was not found.");
}