using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book3WebFrontEnd.Models
{
    public class BookModel
    {
        public class Book
        {
            public Guid BookId { get; set; }
            public string BookTitle { get; set; }
        }

        public List<Book> Books { get; set; }
    }
}