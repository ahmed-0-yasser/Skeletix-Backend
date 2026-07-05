using Microsoft.EntityFrameworkCore;
using Skeletix.Contracts.AI;
using Skeletix.Contracts.MedicalFiles;
using Skeletix.Persistence;
using Skeletix.Services.Interfaces;

namespace Skeletix.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAiService _aiService;

        public ReportService(
            ApplicationDbContext context,
            IAiService aiService)
        {
            _context = context;
            _aiService = aiService;
        }

        // =========================
        // QUICK RESULT (LATEST FILE ONLY)
        // =========================
        public async Task<AiResultDto> GetQuickResultAsync(
            int patientId,
            CancellationToken cancellationToken = default)
        {
            var file = await _context.MedicalFiles
                .Where(x => x.PatientId == patientId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (file == null)
                throw new Exception("No medical file found");

            var result = await _aiService.AnalyzeAsync(
                file.FilePath,
                cancellationToken);

            return result;
        }

        // =========================
        // DASHBOARD STATS
        // =========================
        public async Task<ReportsDashboardDto> GetDashboardStatsAsync(
            int patientId,
            CancellationToken cancellationToken = default)
        {
            var totalFiles = await _context.MedicalFiles
                .Where(x => x.PatientId == patientId)
                .CountAsync(cancellationToken);

            var completedReports = await _context.AnalysisReports
                .Where(x => x.MedicalFile.PatientId == patientId)
                .CountAsync(cancellationToken);

            var pending = await _context.MedicalFiles
                .Where(x => x.PatientId == patientId && x.Status == "Pending")
                .CountAsync(cancellationToken);

            var avg = await _context.AnalysisReports
                .Where(x => x.MedicalFile.PatientId == patientId)
                .AnyAsync(cancellationToken)
                ? await _context.AnalysisReports
                    .Where(x => x.MedicalFile.PatientId == patientId)
                    .AverageAsync(x => x.AiConfidenceScore, cancellationToken)
                : 0;

            return new ReportsDashboardDto
            {
                TotalFiles = totalFiles,
                CompletedReports = completedReports,
                PendingReports = pending,
                AverageConfidence = avg
            };
        }
    }
}