using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class PenaltyMap : EntityTypeConfiguration<Penalty>
    {
        public PenaltyMap()
        {
            // Primary Key
            this.HasKey(t => t.PenaltyId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Penalties");
            this.Property(t => t.PenaltyId).HasColumnName("PenaltyId");
            this.Property(t => t.BookOperationId).HasColumnName("BookOperationId");
            this.Property(t => t.PenaltyQuantity).HasColumnName("PenaltyQuantity");

            // Relationships
            this.HasRequired(t => t.BookOperation)
                .WithMany(t => t.Penalties)
                .HasForeignKey(d => d.BookOperationId);

        }
    }
}
