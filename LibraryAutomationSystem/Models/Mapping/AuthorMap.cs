using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            // Primary Key
            this.HasKey(t => t.AuthorId);

            // Properties
            this.Property(t => t.AuthorName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Authors");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.AuthorName).HasColumnName("AuthorName");
        }
    }
}
