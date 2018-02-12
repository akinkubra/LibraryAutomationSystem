using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class PasswordRecoveryMap : EntityTypeConfiguration<PasswordRecovery>
    {
        public PasswordRecoveryMap()
        {
            // Primary Key
            this.HasKey(t => t.RecoveryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("PasswordRecovery");
            this.Property(t => t.RecoveryId).HasColumnName("RecoveryId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RecoStatus).HasColumnName("RecoStatus");
            this.Property(t => t.RecoCount).HasColumnName("RecoCount");
            this.Property(t => t.RecoDate).HasColumnName("RecoDate");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.PasswordRecoveries)
                .HasForeignKey(d => d.UserId);

        }
    }
}
