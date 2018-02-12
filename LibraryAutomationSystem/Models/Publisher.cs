using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            this.Book_Publisher = new List<Book_Publisher>();
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book_Publisher> Book_Publisher { get; set; }
    }
}
