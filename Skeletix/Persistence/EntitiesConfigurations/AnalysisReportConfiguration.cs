using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeletix.Entities;

namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class AnalysisReportConfiguration : IEntityTypeConfiguration<AnalysisReport>
{
    public void Configure(EntityTypeBuilder<AnalysisReport> builder)
    {
        // =====================
        // Primary Key
        // =====================
        builder.HasKey(x => x.ReportId);

        // =====================
        // Required fields
        // =====================
        builder.Property(x => x.AiConfidenceScore)
               .IsRequired();

        builder.Property(x => x.FileId)
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        // =====================
        // AI TEXT FIELDS (IMPORTANT FIX)
        // =====================

        builder.Property(x => x.Summary)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Recommendations)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.SeverityLevel)
               .IsRequired()
               .HasMaxLength(50);

        // =====================
        // IMAGE PATH (AI OUTPUT)
        // =====================
        builder.Property(x => x.ResultImagePath)
               .HasColumnType("nvarchar(max)");

        // =====================
        // RELATIONS
        // =====================

        builder.HasOne(x => x.MedicalFile)
               .WithMany(f => f.AnalysisReports)
               .HasForeignKey(x => x.FileId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.AnalysisFindings)
               .WithOne(f => f.AnalysisReport)
               .HasForeignKey(f => f.ReportId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}