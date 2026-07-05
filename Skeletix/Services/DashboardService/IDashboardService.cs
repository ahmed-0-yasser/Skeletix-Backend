using Skeletix.Contracts.Dashboard;

namespace Skeletix.Services.DashboardService;

public interface IDashboardService
{
    Task<DashboardResponse> GetStatsAsync(
      int patientId,
      CancellationToken cancellationToken = default);
}
