using FluentValidation;
using Users.Domain.Users.Entities;

namespace Users.Application.Users.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue)
            .WithMessage("User ID must be a positive integer.");
    }
}