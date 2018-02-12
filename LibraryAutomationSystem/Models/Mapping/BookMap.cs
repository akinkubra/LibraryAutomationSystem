using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            // Primary Key
            this.HasKey(t => t.BookId);

            // Properties
            this.Property(t => t.BookName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Books");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.BookName).HasColumnName("BookName");
            this.Property(t => t.BookQuantity).HasColumnName("BookQuantity");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Books)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
