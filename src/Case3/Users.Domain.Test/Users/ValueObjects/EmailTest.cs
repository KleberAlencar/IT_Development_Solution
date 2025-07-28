using Users.Domain.Users.ValueObjects;
using Users.Domain.Users.ValueObjects.Exceptions;

namespace Users.Domain.Test.Users.ValueObjects;

public class EmailTest
{
    [Theory]
    [InlineData("kleber@outlook.com")]
    [InlineData("kleber@gmail.com")]
    [InlineData("kleber@hotmail.com")]
    public void Create_ShouldCreate_WhenCreateNewEmail(string address)
    {
        var email = Email.Create(address);
        Assert.Equal(email.Address, address);       
    }
    
    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    public void Create_ShouldCreateFail_WhenCreateNewEmail(string address)
    {
        Assert.Throws<InvalidEmailLengthException>(() =>
        {
            var email = Email.Create(address);       
        });
    }
    
    [Theory]
    [InlineData("123456!@#")]
    [InlineData("teste_string_sem_valor")]
    public void Create_ShouldCreateFail_WhenEmailIsNotValid(string address)
    {
        Assert.Throws<InvalidEmailException>(() =>
        {
            var email = Email.Create(address);       
        });
    }    
}