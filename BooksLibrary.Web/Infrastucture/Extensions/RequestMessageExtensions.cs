﻿using System.Net.Http;
using System.Web.Http.Dependencies;
using BooksLibrary.Services.Abstract;

namespace BooksLibrary.Web.Infrastucture.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));
            return service;
        }
    }
}