
namespace BooksLibrary.Data.Configuration
{
    public class BookConfiguration:EntityBaseConfiguration<Book>
    {
        public BookConfiguration()
        {

            Property(b => b.Id).HasColumnName("book_id");
            HasMany(b => b.Authors).WithMany(a => a.Books).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("author_id");
                cs.ToTable("BOOK_AUTHOR");
            });
        }
    }
}
