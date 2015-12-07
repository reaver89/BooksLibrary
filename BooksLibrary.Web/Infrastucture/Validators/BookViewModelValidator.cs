
using BooksLibrary.Web.Models;
using FluentValidation;

namespace BooksLibrary.Web.Infrastucture.Validators
{
    public class BookViewModelValidator: AbstractValidator<BookViewModel>
    {
        public BookViewModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Enter a title");
            RuleFor(x => x.Year).NotEmpty().GreaterThan(0).WithMessage("Enter a year");
            RuleFor(x => x.Edition).Length(0, 200).WithMessage("Edition must not be greater then 200 symbols");
            RuleFor(x => x.Rating).InclusiveBetween((byte)0, (byte)5).WithMessage("Rating must be less than or equal to 5");
        }
    }
}