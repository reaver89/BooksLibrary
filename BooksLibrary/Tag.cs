using System.Collections.Generic;

namespace BooksLibrary
{
    public class Tag : IEntityBase
    {
        public Tag()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
