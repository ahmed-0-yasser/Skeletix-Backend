using Microsoft.EntityFrameworkCore;
using Skeletix.Entities;
using Skeletix.Persistence;
using Skeletix.Services.Interfaces;
using System.Security.Claims;

namespace Skeletix.Services;

public class MedicalFileService : IMedicalFileService
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MedicalFileService(
        ApplicationDbContext context,
        IWebHostEnvironment environment,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _environment = environment;
        _httpContextAccessor = httpContextAccessor;
    }

    // ================= UPLOAD =================
    public async Task<MedicalFile> UploadAsync(
        IFormFile file,
        string fileType,
        CancellationToken cancellationToken = default)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is required.");

        int patientId = GetCurrentPatientId();

        var uploadsPath = Path.Combine(_environment.ContentRootPath, "Uploads");

        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        var uniqueName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(uploadsPath, uniqueName);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var medicalFile = new MedicalFile
        {
            PatientId = patientId,
            FileName = file.FileName,
            FileType = fileType,
            FileFormat = Path.GetExtension(file.FileName),
            FileSize = file.Length,
            FilePath = fullPath,

            Status = "Uploaded",

            // 🔥 ثابتة في السيرفر (مش من اليوزر)
            Priority = "High",

            CreatedAt = DateTime.UtcNow
        };

        _context.MedicalFiles.Add(medicalFile);
        await _context.SaveChangesAsync(cancellationToken);

        return medicalFile;
    }

    // ================= USER =================
    private int GetCurrentPatientId()
    {
        var userId = _httpContextAccessor.HttpContext?
            .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new Exception("Unauthorized");

        return int.Parse(userId);
    }
}