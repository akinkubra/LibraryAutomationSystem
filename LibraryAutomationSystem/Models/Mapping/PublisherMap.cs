using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class PublisherMap : EntityTypeConfiguration<Publisher>
    {
        public PublisherMap()
        {
            // Primary Key
            this.HasKey(t => t.PublisherId);

            // Properties
            this.Property(t => t.PublisherName)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Publishers");
            this.Property(t => t.PublisherId).HasColumnName("PublisherId");
            this.Property(t => t.PublisherName).HasColumnName("PublisherName");
        }
    }
}
