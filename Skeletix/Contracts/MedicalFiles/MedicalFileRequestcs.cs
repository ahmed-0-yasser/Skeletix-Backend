using Microsoft.AspNetCore.Http;

namespace Skeletix.Contracts.MedicalFiles
{
    public class MedicalFileRequest
    {
        public IFormFile File { get; set; } = null!;
        public string FileType { get; set; } = null!;
    }
}