using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Book_Publisher
    {
        public int Book_Publisher_Id { get; set; }
        public int BookId { get; set; }
        public int PublisherId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
