using Skeletix.Contracts.AI;
using Skeletix.Contracts.MedicalFiles;

namespace Skeletix.Services.Interfaces
{
    public interface IReportService
    {
        Task<AiResultDto> GetQuickResultAsync(
            int patientId,
            CancellationToken cancellationToken = default);

        Task<ReportsDashboardDto> GetDashboardStatsAsync(
            int patientId,
            CancellationToken cancellationToken = default);
    }
}