using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using AutoMapper;
using BooksLibrary.Data.Infrastructure;
using BooksLibrary.Data.Repositories;
using BooksLibrary.Web.Infrastucture.Core;
using BooksLibrary.Web.Models;

namespace BooksLibrary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/genres")]
    public class GenresController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Genre> _genresRepository;
        public GenresController(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork, IEntityBaseRepository<Genre> genresRepository) :
            base(errorsRepository, unitOfWork)
        {
            _genresRepository = genresRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var genres = _genresRepository.GetAll().ToList();
                IEnumerable<GenreViewModel> genresViewModels = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);
                response = request.CreateResponse<IEnumerable<GenreViewModel>>(HttpStatusCode.OK, genresViewModels);
                return response;
            });
        }
    }
}