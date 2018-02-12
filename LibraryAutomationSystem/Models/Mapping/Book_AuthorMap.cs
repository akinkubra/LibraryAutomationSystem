using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class Book_AuthorMap : EntityTypeConfiguration<Book_Author>
    {
        public Book_AuthorMap()
        {
            // Primary Key
            this.HasKey(t => t.Book_Author_Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Book_Author");
            this.Property(t => t.Book_Author_Id).HasColumnName("Book_Author_Id");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");

            // Relationships
            this.HasRequired(t => t.Author)
                .WithMany(t => t.Book_Author)
                .HasForeignKey(d => d.AuthorId);
            this.HasRequired(t => t.Book)
                .WithMany(t => t.Book_Author)
                .HasForeignKey(d => d.BookId);

        }
    }
}
