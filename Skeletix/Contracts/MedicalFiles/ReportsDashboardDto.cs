namespace Skeletix.Contracts.MedicalFiles
{
    public class ReportsDashboardDto
    {
        public int TotalFiles { get; set; }
        public int CompletedReports { get; set; }
        public int PendingReports { get; set; }
        public double AverageConfidence { get; set; }
    }
}