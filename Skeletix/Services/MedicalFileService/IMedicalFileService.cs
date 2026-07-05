using Microsoft.AspNetCore.Http;
using Skeletix.Contracts.AI;
using Skeletix.Entities;

namespace Skeletix.Services.Interfaces
{
    public interface IMedicalFileService
    {
        Task<MedicalFile> UploadAsync(
            IFormFile file,
            string fileType,
            CancellationToken cancellationToken = default);

    }
}