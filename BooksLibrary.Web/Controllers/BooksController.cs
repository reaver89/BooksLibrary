using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BooksLibrary.Data.Infrastructure;
using BooksLibrary.Data.Repositories;
using BooksLibrary.Web.Infrastucture.Core;
using BooksLibrary.Web.Models;

namespace BooksLibrary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/books")]
    public class BooksController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Book> _booksRepository;

        public BooksController(IEntityBaseRepository<Book> booksRepository, IEntityBaseRepository<Error> errorsRepository,
            IUnitOfWork unitOfWork) : base(errorsRepository, unitOfWork)
        {
            _booksRepository = booksRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var books = _booksRepository.GetAll().OrderByDescending(x => x.Year).Take(6).ToList();
                IEnumerable<BookViewModel> bookViewModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
                response = request.CreateResponse<IEnumerable<BookViewModel>>(HttpStatusCode.OK, bookViewModels);
                return response;
            });
        }

    }
}