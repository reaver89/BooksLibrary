using System;
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

        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () => HttpResponseMessage(request, filter, currentPage, currentPageSize));

        }

        private HttpResponseMessage HttpResponseMessage(HttpRequestMessage request, string filter, int currentPage,
            int currentPageSize)
        {
            List<Book> books;
            if (!string.IsNullOrEmpty(filter))
            {
                books =
                    _booksRepository.GetAll()
                        .OrderBy(m => m.Id)
                        .Where(m => m.Title.ToLower().Contains(filter.ToLower().Trim()))
                        .ToList();
            }
            else
            {
                books = _booksRepository.GetAll().ToList();
            }
            var totalMovies = books.Count();
            books = books.Skip(currentPage*currentPageSize).Take(currentPageSize).ToList();
            IEnumerable<BookViewModel> bookViewModels = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            PaginationSet<BookViewModel> pagedSet = new PaginationSet<BookViewModel>()
            {
                Page = currentPage,
                TotalCount = totalMovies,
                TotalPages = (int) Math.Ceiling((decimal) totalMovies/currentPageSize),
                Items = bookViewModels
            };
            var response = request.CreateResponse<PaginationSet<BookViewModel>>(HttpStatusCode.OK, pagedSet);
            return response;
        }
    }
}