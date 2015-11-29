
using System.Collections.Generic;

namespace BooksLibrary
{
    public class Genre : IEntityBase
    {
        public Genre()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentGenreId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
