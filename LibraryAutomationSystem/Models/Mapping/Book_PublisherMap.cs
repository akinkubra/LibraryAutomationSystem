using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class Book_PublisherMap : EntityTypeConfiguration<Book_Publisher>
    {
        public Book_PublisherMap()
        {
            // Primary Key
            this.HasKey(t => t.Book_Publisher_Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Book_Publisher");
            this.Property(t => t.Book_Publisher_Id).HasColumnName("Book_Publisher_Id");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.PublisherId).HasColumnName("PublisherId");

            // Relationships
            this.HasRequired(t => t.Book)
                .WithMany(t => t.Book_Publisher)
                .HasForeignKey(d => d.BookId);
            this.HasRequired(t => t.Publisher)
                .WithMany(t => t.Book_Publisher)
                .HasForeignKey(d => d.PublisherId);

        }
    }
}
