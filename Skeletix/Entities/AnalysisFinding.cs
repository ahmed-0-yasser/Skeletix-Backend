namespace Skeletix.Entities;

public class AnalysisFinding
{
    public int FindingId { get; set; }

    public int ReportId { get; set; }

    public string FindingType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string ConfidenceLevel { get; set; } = null!;
    public string Severity { get; set; } = null!;

    // Navigation
    public AnalysisReport AnalysisReport { get; set; } = null!;
}
