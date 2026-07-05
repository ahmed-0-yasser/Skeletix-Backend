using Microsoft.EntityFrameworkCore;
using Skeletix.Configurations;
using Skeletix.Entities;
using SurveyBasket.Persistence.EntitiesConfigurations;

namespace Skeletix.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<MedicalFile> MedicalFiles { get; set; } = null!;
        public DbSet<AnalysisReport> AnalysisReports { get; set; } = null!;
        public DbSet<AnalysisFinding> AnalysisFindings { get; set; } = null!;








        //meeeeee
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalFileConfiguration());
            modelBuilder.ApplyConfiguration(new AnalysisReportConfiguration());
            modelBuilder.ApplyConfiguration(new AnalysisFindingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
