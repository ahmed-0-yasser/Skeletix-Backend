namespace Skeletix.Contracts.Dashboard;

public class DashboardResponse
{
    public int TotalFiles { get; set; }
    public int TotalReports { get; set; }
    public bool IsAnalysisActive { get; set; }

    public LastAnalyzedFileDto? LastAnalyzedFile { get; set; }
}
public class LastAnalyzedFileDto
{
    public int FileId { get; set; }
    public string? FileName { get; set; }
    public DateTime AnalyzedAt { get; set; }
}
