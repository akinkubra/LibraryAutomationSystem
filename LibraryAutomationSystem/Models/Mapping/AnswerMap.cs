using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.AnswerId);

            // Properties
            this.Property(t => t.Answer1)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Answers");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.Answer1).HasColumnName("Answer");
        }
    }
}
