
using System.Linq;
using AutoMapper;
using BooksLibrary.Web.Models;

namespace BooksLibrary.Web.Infrastucture.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(vm => vm.Genre, map => map.MapFrom(m => string.Join(",", m.Genres.Select(x => x.Name))));
            Mapper.CreateMap<Genre, GenreViewModel>();
        }
    }
}