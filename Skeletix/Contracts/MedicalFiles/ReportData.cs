

namespace Skeletix.Contracts.MedicalFiles
{
    public class ReportData
    {
        
            public int ReportId { get; set; }

            public string? PatientName { get; set; }

            public string? Diagnosis { get; set; }

            public double ConfidenceScore { get; set; }

            public string? Recommendations { get; set; }

            public string? SeverityLevel { get; set; }

            public string? ImageUrl { get; set; }
        
    }

}
