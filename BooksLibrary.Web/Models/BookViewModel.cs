using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BooksLibrary.Web.Infrastucture.Validators;

namespace BooksLibrary.Web.Models
{

    public class BookViewModel : IValidatableObject
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TitleEng { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Edition { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new BookViewModelValidator();
            var results = validator.Validate(this);
            return results.Errors.Select(i => new ValidationResult(i.ErrorMessage, new[] { i.PropertyName }));
        }
    }
}