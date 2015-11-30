
namespace BooksLibrary.Data.Configuration
{
    public class BookTagConfiguration:EntityBaseConfiguration<BookTag>
    {
        public BookTagConfiguration()
        {
            Property(bt => bt.Id).HasColumnName("book_tag_id");
            Property(bt => bt.BookId).IsRequired().HasColumnName("book_id");
            Property(bt => bt.TagId).IsRequired().HasColumnName("tag_id");
        }
    }
}
