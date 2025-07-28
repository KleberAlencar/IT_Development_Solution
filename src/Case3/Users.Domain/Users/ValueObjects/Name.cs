using Users.Domain.Shared.ValueObjects;
using Users.Domain.Users.ValueObjects.Exceptions;

namespace Users.Domain.Users.ValueObjects;

public sealed record Name : ValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 60;
    
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // factory method to create a Name instance
    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) ||
            string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrEmpty(lastName) ||
            string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidNameException("First name and last name cannot be null or empty.");
        }
        
        if (firstName.Length < MinLength)
        {
            throw new InvalidFirstNameLengthException($"First name must be at least {MinLength} characters long.");
        }

        if (firstName.Length > MaxLength)
        {
            throw new InvalidFirstNameLengthException($"First name cannot be more than {MaxLength} characters.");
        }
        
        if (lastName.Length < MinLength)
        {
            throw new InvalidLastNameLengthException($"Last name must be at least {MinLength} characters long.");
        }

        if (lastName.Length > MaxLength)
        {
            throw new InvalidLastNameLengthException($"Last name cannot be more than {MaxLength} characters.");
        }
        
        return new Name(firstName, lastName);
    }
    
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;  
    
    // operators - convert object Name to string
    public static implicit operator string(Name name) => name.ToString();
    
    // overrides - return full name as a string
    public override string ToString() => $"{FirstName} {LastName}";
}