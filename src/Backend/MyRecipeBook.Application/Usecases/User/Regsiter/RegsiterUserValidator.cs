using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(user => user.Email).EmailAddress().WithMessage("The follow email is not a valid email");
        RuleFor(user => user.Password.Length).GreaterThan(6).WithMessage("Password should be greather than 6 characters");
    }
}