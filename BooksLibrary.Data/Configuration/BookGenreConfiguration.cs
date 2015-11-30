
namespace BooksLibrary.Data.Configuration
{
    public class BookGenreConfiguration:EntityBaseConfiguration<BookGenre>
    {
        public BookGenreConfiguration()
        {
            Property(bg => bg.Id).HasColumnName("book_genre_id");
            Property(bg => bg.BookId).HasColumnName("book_id").IsRequired();
            Property(bg => bg.GenreId).HasColumnName("genre_id").IsRequired();
        }
    }
}
