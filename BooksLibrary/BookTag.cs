
namespace BooksLibrary
{
    public class BookTag:IEntityBase
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }
    }
}
