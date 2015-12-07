using BooksLibrary.Web.Models;
using FluentValidation;

namespace BooksLibrary.Web.Infrastucture.Validators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(r => r.UserName).NotEmpty().WithMessage("Invalid username");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Invalid password");
        }
    }
}