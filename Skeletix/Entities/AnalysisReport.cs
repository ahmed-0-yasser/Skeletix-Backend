namespace Skeletix.Entities;

public class AnalysisReport
{
    public int ReportId { get; set; }

    public int FileId { get; set; }

    public double AiConfidenceScore { get; set; }
    public string Summary { get; set; } = null!;
    public string Recommendations { get; set; } = null!;
    public string SeverityLevel { get; set; } = null!;
    public string? ResultImagePath { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation
    public MedicalFile MedicalFile { get; set; } = null!;
    public ICollection<AnalysisFinding> AnalysisFindings { get; set; } = new List<AnalysisFinding>();
}
