using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryAutomationSystem.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionId);

            // Properties
            this.Property(t => t.Question1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Question1).HasColumnName("Question");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");

            // Relationships
            this.HasRequired(t => t.Answer)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.AnswerId);

        }
    }
}
