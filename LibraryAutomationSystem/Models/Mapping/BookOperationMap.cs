using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class BookOperationMap : EntityTypeConfiguration<BookOperation>
    {
        public BookOperationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired();

            this.Property(t => t.CategoryName)
                .IsRequired();

            this.Property(t => t.BookName)
                .IsRequired();

            this.Property(t => t.AuthorName)
                .IsRequired();

            this.Property(t => t.PublisherName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("BookOperations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.BookName).HasColumnName("BookName");
            this.Property(t => t.AuthorName).HasColumnName("AuthorName");
            this.Property(t => t.PublisherName).HasColumnName("PublisherName");
            this.Property(t => t.ReceivingDate).HasColumnName("ReceivingDate");
            this.Property(t => t.GivingDate).HasColumnName("GivingDate");
        }
    }
}
