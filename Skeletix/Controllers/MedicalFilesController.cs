using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skeletix.Contracts.MedicalFiles;
using Skeletix.Services.Interfaces;

namespace Skeletix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MedicalFilesController : ControllerBase
    {
        private readonly IMedicalFileService _medicalFileService;

        public MedicalFilesController(IMedicalFileService medicalFileService)
        {
            _medicalFileService = medicalFileService;
        }

        // ============================
        // UPLOAD ONLY
        // ============================
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(
            [FromForm] MedicalFileRequest request,
            CancellationToken cancellationToken)
        {
            if (request.File == null)
                return BadRequest("File is required.");

            var medicalFile = await _medicalFileService.UploadAsync(
                request.File,
                request.FileType,
                cancellationToken);

            return Ok(new
            {
                message = "File uploaded successfully",
                data = medicalFile
            });
        }
    }
}