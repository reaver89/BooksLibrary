using System.Collections.Generic;

namespace BooksLibrary
{
    public class Author : IEntityBase
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
