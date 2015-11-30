
namespace BooksLibrary.Data.Configuration
{
    public class AuthorConfiguration:EntityBaseConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(a => a.Id).HasColumnName("author_id");
            Property(a => a.FullName).HasColumnName("full_name").HasMaxLength(300);
            Property(a => a.Details).HasMaxLength(200);
            HasMany(a => a.Books).WithMany(b => b.Authors).Map(cs =>
            {
                cs.MapLeftKey("author_id");
                cs.MapRightKey("book_id");
                cs.ToTable("BOOK_AUTHOR");
            });
        }
    }
}
