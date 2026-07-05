using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeletix.Entities;

namespace Skeletix.Configurations
{
    public class AnalysisFindingConfiguration : IEntityTypeConfiguration<AnalysisFinding>
    {
        public void Configure(EntityTypeBuilder<AnalysisFinding> builder)
        {
            // Primary key
            builder.HasKey(f => f.FindingId);

            // Properties
            builder.Property(f => f.FindingType)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(f => f.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(f => f.Location)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(f => f.ConfidenceLevel)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(f => f.Severity)
                   .IsRequired()
                   .HasMaxLength(50);

             // كل تقرير ممكن يكون ليه اكتر م تحليل
            builder.HasOne(f => f.AnalysisReport)
                   .WithMany(r => r.AnalysisFindings) 
                   .HasForeignKey(f => f.ReportId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
