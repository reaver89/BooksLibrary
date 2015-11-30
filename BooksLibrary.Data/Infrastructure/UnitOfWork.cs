
namespace BooksLibrary.Data.Infrastructure
{
    public class UnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private BooksLibraryContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public BooksLibraryContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
