using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class BookOperation
    {
        public BookOperation()
        {
            this.Penalties = new List<Penalty>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public Nullable<System.DateTime> ReceivingDate { get; set; }
        public Nullable<System.DateTime> GivingDate { get; set; }
        public virtual ICollection<Penalty> Penalties { get; set; }
    }
}
