using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksRoutesEditor.api.Models
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public int _pivot_book_id { get; set; }
        public int _pivot_author_id { get; set; }
    }

    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string isbn { get; set; }
        public string cover { get; set; }
        public string description { get; set; }
        public List<Author> authors { get; set; }
    }
}
