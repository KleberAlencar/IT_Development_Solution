using Users.Domain.Shared.Entities;
using Users.Domain.Users.ValueObjects;

namespace Users.Domain.Users.Entities;

public class User : Entity
{
    private User(
        int id, 
        Name name, 
        Email email) : base(id)
    {
        Name = name;
        Email = email;
    }
    
    private User(
        int id, 
        string firstName, 
        string lastName,
        string email) : base(id)
    {
        Name = Name.Create(firstName, lastName);
        Email = Email.Create(email);
    }
    
    public static User Create(
        int id,
        Name name,
        Email email)
    {
        return new(id, name, email);
    }    
    
    public static User Create(
        int id, 
        string firstName, 
        string lastName,
        string email)
    {
        return new(id, firstName, lastName, email);
    }

    public Name Name { get; }
    public Email Email { get; }

    public override string ToString() => Name;
}