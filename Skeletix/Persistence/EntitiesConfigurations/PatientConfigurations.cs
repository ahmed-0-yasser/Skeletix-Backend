using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeletix.Entities;

namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        // Primary Key
        builder.HasKey(x => x.PatientId);

        // Properties
        builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(x => x.LastName)
              .IsRequired()
              .HasMaxLength(200);


        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.Property(x => x.PasswordHash)
               .IsRequired();

        builder.Property(x => x.Gender)
               .IsRequired()
               .HasMaxLength(10);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        // كل مريض ممكن يكون ليه اكتر م فايل 
        builder.HasMany(x => x.MedicalFiles)
               .WithOne(x => x.Patient)
               .HasForeignKey(x => x.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

       
    }
}
