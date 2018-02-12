using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class BookViewMap : EntityTypeConfiguration<BookView>
    {
        public BookViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CategoryId, t.CategoryName, t.BookName, t.AuthorName, t.PublisherName, t.BookId });

            // Properties
            this.Property(t => t.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CategoryName)
                .IsRequired();

            this.Property(t => t.BookName)
                .IsRequired();

            this.Property(t => t.AuthorName)
                .IsRequired();

            this.Property(t => t.PublisherName)
                .IsRequired();

            this.Property(t => t.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BookView");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.BookName).HasColumnName("BookName");
            this.Property(t => t.AuthorName).HasColumnName("AuthorName");
            this.Property(t => t.PublisherName).HasColumnName("PublisherName");
            this.Property(t => t.BookQuantity).HasColumnName("BookQuantity");
            this.Property(t => t.BookId).HasColumnName("BookId");
        }
    }
}
