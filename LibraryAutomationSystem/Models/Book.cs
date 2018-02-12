using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Book
    {
        public Book()
        {
            this.Book_Author = new List<Book_Author>();
            this.Book_Publisher = new List<Book_Publisher>();
        }

        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public Nullable<int> BookQuantity { get; set; }
        public virtual ICollection<Book_Author> Book_Author { get; set; }
        public virtual ICollection<Book_Publisher> Book_Publisher { get; set; }
        public virtual Category Category { get; set; }
    }
}
