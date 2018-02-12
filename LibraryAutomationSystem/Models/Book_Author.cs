using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Book_Author
    {
        public int Book_Author_Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
