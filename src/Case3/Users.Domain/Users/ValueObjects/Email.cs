using System.Text.RegularExpressions;
using Users.Domain.Shared.ValueObjects;
using Users.Domain.Users.ValueObjects.Exceptions;

namespace Users.Domain.Users.ValueObjects;

public sealed partial record Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    public const int MinLength = 6;
    public const int MaxLength = 100;
    
    private Email(string address)
    {
        Address = address;
    }
    
    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address) ||
            string.IsNullOrWhiteSpace(address))
            throw new InvalidEmailLengthException($"Email must not be empty.");

        address = address.Trim();
        address = address.ToLower();
        
        if (!EmailRegex().IsMatch(address))
            throw new InvalidEmailException($"Email {address} is not valid.");       
        
        return new Email(address);       
    }    
    
    public string Address { get; }    
    
    public static implicit operator string(Email email) => email.ToString();
    
    public override string ToString() => Address;
    
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();    
}