
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BooksLibrary.Data.Configuration;
using BooksLibrary.Membership;

namespace BooksLibrary.Data
{
    public class BooksLibraryContext :DbContext
    {
        public BooksLibraryContext():base("BooksLibrary")
        {
            Database.SetInitializer<BooksLibraryContext>(null);
        }

        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Author> AuthorSet { get; set; }
        public IDbSet<Book> BookSet { get; set; }
        public IDbSet<Genre> GenreSet { get; set; }
        public IDbSet<Tag> TagSet { get; set; }
        public IDbSet<BookAuthor> BookAuthorSet { get; set; }
        public IDbSet<BookGenre> BookGenreSet { get; set; }
        public IDbSet<BookTag> BookTagSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new BookAuthorConfiguration());
            modelBuilder.Configurations.Add(new BookGenreConfiguration());
            modelBuilder.Configurations.Add(new BookTagConfiguration());
        }
    }
}
