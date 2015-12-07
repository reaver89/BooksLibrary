using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BooksLibrary.Data;
using BooksLibrary.Data.Infrastructure;
using BooksLibrary.Data.Repositories;
using BooksLibrary.Membership;
using BooksLibrary.Services.Abstract;
using BooksLibrary.Web.Infrastucture.Core;
using BooksLibrary.Web.Models;

namespace BooksLibrary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork, IMembershipService membershipService)
            : base(errorsRepository, unitOfWork)
        {
            _membershipService = membershipService;
        }


        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (ModelState.IsValid)
                {
                    MembershipContext userContext = _membershipService.ValidateUser(viewModel.Username, viewModel.Password);
                    response = request.CreateResponse(HttpStatusCode.OK, userContext.User != null ? new { success = true } : new { success = false });
                }
                else response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                return response;
            });
        }


        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (!ModelState.IsValid) { response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false }); }
                else
                {
                    User user = _membershipService.CreateUser(viewModel.UserName, viewModel.Email, viewModel.Password, new int[] { 1 });
                    response = request.CreateResponse(HttpStatusCode.OK, user != null ? new { success = true } : new { success = false });
                }
                return response;
            });
        }
    }
}