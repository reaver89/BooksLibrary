
namespace BooksLibrary
{
    public class BookGenre:IEntityBase
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
