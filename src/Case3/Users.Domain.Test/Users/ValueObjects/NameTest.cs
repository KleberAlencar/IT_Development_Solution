using Users.Domain.Users.ValueObjects;
using Users.Domain.Users.ValueObjects.Exceptions;

namespace Users.Domain.Test.Users.ValueObjects;

public class NameTest
{
    private readonly Name _name = Name.Create("John", "Doe");

    [Fact]
    public void Create_ToString_ShouldReturnFullName()
    {
        // Assert
        Assert.Equal("John Doe", _name.ToString());
    }

    [Fact]
    public void Create_ImplicitOperator_ShouldConvertNameToString()
    {
        // Act
        string fullName = _name;

        // Assert
        Assert.Equal("John Doe", fullName);
    }
    
    [Fact]
    public void Create_ShouldCreate_WhenCreateNewName()
    {
        // Assert
        Assert.Equal("John Doe", _name.ToString());
    }    
    
    [Fact]
    public void Create_ShouldThrow_WhenFirstNameTooShort()
    {
        Assert.Throws<InvalidFirstNameLengthException>(() =>
        {
            var name = Name.Create("J", "Doe");
        });
    }
    
    [Fact]
    public void Create_ShouldThrow_WhenLastNameTooShort()
    {
        Assert.Throws<InvalidLastNameLengthException>(() =>
        {
            var name = Name.Create("John", "D");
        });
    }    
}