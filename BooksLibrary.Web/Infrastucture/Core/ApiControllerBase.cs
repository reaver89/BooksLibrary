﻿using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksLibrary.Data.Infrastructure;
using BooksLibrary.Data.Repositories;

namespace BooksLibrary.Web.Infrastucture.Core
{
    public class ApiControllerBase : ApiController
    {
        protected readonly IEntityBaseRepository<Error> _errorsRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApiControllerBase(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
        {
            _errorsRepository = errorsRepository;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response;
            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Add(error);
                _unitOfWork.Commit();
            }
            catch
            {

            }
        }
    }
}