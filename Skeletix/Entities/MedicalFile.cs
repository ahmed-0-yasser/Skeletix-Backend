namespace Skeletix.Entities;

public class MedicalFile
{
    public int FileId { get; set; }

    public int PatientId { get; set; }

    public string FileName { get; set; } = null!;
    public string FileType { get; set; } = null!;
    public string FileFormat { get; set; } = null!;
    public long FileSize { get; set; }

    public string FilePath { get; set; } = null!;
    public string Status { get; set; } = null!;

    public string Priority { get; set; } = "High";

    public DateTime CreatedAt { get; set; }

    public Patient Patient { get; set; } = null!;
    public ICollection<AnalysisReport> AnalysisReports { get; set; } = new List<AnalysisReport>();
}