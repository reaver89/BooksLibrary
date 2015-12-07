using BooksLibrary.Web.Models;
using FluentValidation;

namespace BooksLibrary.Web.Infrastucture.Validators
{
    public class LoginViewModelValidator: AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(r => r.Username).NotEmpty().WithMessage("Invalid username");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Invalid password");
        }
    }
}