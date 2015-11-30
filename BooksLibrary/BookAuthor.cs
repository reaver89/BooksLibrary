
namespace BooksLibrary
{
    public class BookAuthor:IEntityBase
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
