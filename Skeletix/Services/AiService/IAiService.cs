using Skeletix.Contracts.AI;
using System.Threading;
using System.Threading.Tasks;

namespace Skeletix.Services.Interfaces
{
    public interface IAiService
    {
        Task<AiResultDto> AnalyzeAsync(
            string filePath,
            CancellationToken cancellationToken = default);
    }
}