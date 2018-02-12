using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class BookView
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public Nullable<int> BookQuantity { get; set; }
        public int BookId { get; set; }
    }
}
