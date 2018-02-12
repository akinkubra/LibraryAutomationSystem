using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Author
    {
        public Author()
        {
            this.Book_Author = new List<Book_Author>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book_Author> Book_Author { get; set; }
    }
}
