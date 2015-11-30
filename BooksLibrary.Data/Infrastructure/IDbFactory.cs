using System;
namespace BooksLibrary.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BooksLibraryContext Init();
    }
}
