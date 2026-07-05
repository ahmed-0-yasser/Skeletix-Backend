using Microsoft.EntityFrameworkCore;
using Skeletix.Contracts.Dashboard;
using Skeletix.Persistence;
using Skeletix.Services.DashboardService;


public class DashboardService(ApplicationDbContext context) : IDashboardService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<DashboardResponse> GetStatsAsync(
        int patientId,
        CancellationToken cancellationToken = default)
    {
        //   بترجع عدد الفايلات اللي عملها اليوزر
        var totalFiles = await _context.MedicalFiles
            .Where(x => x.PatientId == patientId)
            .CountAsync(cancellationToken);

        //   بترجع عدد التقارير اللي عملها اليوزر
        var totalReports = await _context.AnalysisReports
            .Where(r => r.MedicalFile.PatientId == patientId)
            .CountAsync(cancellationToken);

        //  هل في تحليل شغال (Pending)
        var isActive = await _context.MedicalFiles
            .AnyAsync(x => x.PatientId == patientId && x.Status == "Pending", cancellationToken);

        // بترجع اخر حاجه  عملها اليوزر
        var lastReport = await _context.AnalysisReports
            .Include(r => r.MedicalFile)
            .Where(r => r.MedicalFile.PatientId == patientId)
            .OrderByDescending(r => r.CreatedAt)
            .Select(r => new LastAnalyzedFileDto
            {
                FileId = r.FileId,
                FileName = r.MedicalFile.FileName,
                AnalyzedAt = r.CreatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return new DashboardResponse
        {
            TotalFiles = totalFiles,
            TotalReports = totalReports,
            IsAnalysisActive = isActive,
            LastAnalyzedFile = lastReport
        };
    }
}