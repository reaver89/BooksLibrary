
namespace BooksLibrary.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BooksLibraryContext _dbContext;

        public BooksLibraryContext Init()
        {
            return _dbContext ?? (_dbContext = new BooksLibraryContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
