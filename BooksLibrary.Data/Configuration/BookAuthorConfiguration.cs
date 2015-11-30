using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Data.Configuration
{
    class BookAuthorConfiguration:EntityBaseConfiguration<BookAuthor>
    {
        public BookAuthorConfiguration()
        {
            Property(ba => ba.Id).HasColumnName("book_author_id");
            Property(ba => ba.AuthorId).IsRequired().HasColumnName("author_id");
            Property(ba => ba.BookId).IsRequired().HasColumnName("book_id");
        }
    }
}
