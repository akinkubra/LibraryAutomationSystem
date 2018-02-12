using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Books = new List<Book>();
            this.Categories1 = new List<Category>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> TopCategoryId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Category> Categories1 { get; set; }
        public virtual Category Category1 { get; set; }
    }
}
