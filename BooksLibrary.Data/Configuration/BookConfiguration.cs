
namespace BooksLibrary.Data.Configuration
{
    public class BookConfiguration:EntityBaseConfiguration<Book>
    {
        public BookConfiguration()
        {

            Property(b => b.Id).HasColumnName("book_id");
            Property(b => b.Title).IsRequired();
            Property(b => b.Pages).IsRequired();
            Property(b => b.Year).IsRequired();
            Property(b => b.TitleEng).HasColumnName("title_eng");
            Property(b => b.Edition).HasMaxLength(200);
            Property(b => b.Description);

            HasMany(b => b.Authors).WithMany(a => a.Books).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("author_id");
                cs.ToTable("BOOK_AUTHOR");
            });

            HasMany(b => b.Genres).WithMany(g => g.Books).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("genre_id");
                cs.ToTable("BOOK_GENRE");
            });

            HasMany(b => b.Tags).WithMany(t => t.Books).Map(cs =>
            {
                cs.MapLeftKey("book_id");
                cs.MapRightKey("tag_id");
                cs.ToTable("BOOK_TAGS");
            });
        }
    }
}
