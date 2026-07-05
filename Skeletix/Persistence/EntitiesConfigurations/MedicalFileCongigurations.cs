using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeletix.Entities;

namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class MedicalFileConfiguration : IEntityTypeConfiguration<MedicalFile>
{
    public void Configure(EntityTypeBuilder<MedicalFile> builder)
    {
        // Primary Key
        builder.HasKey(x => x.FileId);

        // Properties
        builder.Property(x => x.FileName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.FileType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.FileFormat)
               .IsRequired()
               .HasMaxLength(20);

        // 🔥 FIX (important for AI + cloud URLs)
        builder.Property(x => x.FilePath)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Status)
               .IsRequired()
               .HasMaxLength(30);

        builder.Property(x => x.Priority)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(x => x.FileSize)
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        // Relations
        builder.HasOne(x => x.Patient)
               .WithMany(p => p.MedicalFiles)
               .HasForeignKey(x => x.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.AnalysisReports)
               .WithOne(r => r.MedicalFile)
               .HasForeignKey(r => r.FileId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}