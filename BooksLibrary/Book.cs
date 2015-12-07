using System.Collections.Generic;

namespace BooksLibrary
{
    public class Book : IEntityBase
    {
        public Book()
        {
            Genres = new List<Genre>();
            Authors = new List<Author>();
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TitleEng { get; set; }
        public string Image { get; set; }
        public byte Rating { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Edition { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
