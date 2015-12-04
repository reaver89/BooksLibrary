
using AutoMapper;
using BooksLibrary.Web.Models;

namespace BooksLibrary.Web.Infrastucture.Mappings
{
    public class DomainToViewModelMappingProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Book, BookViewModel>();
        }
    }
}