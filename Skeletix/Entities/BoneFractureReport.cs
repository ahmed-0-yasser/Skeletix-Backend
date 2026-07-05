namespace Skeletix.Entities
{
   
        public class BoneFractureReport
        {
            public int Id { get; set; }

            public string? PatientName { get; set; }
            public int Age { get; set; }
            public string? Gender { get; set; }

            public string? BodyPart { get; set; }
            public string? FractureType { get; set; }
            public float ConfidenceScore { get; set; }

            public string? Diagnosis { get; set; }
            public string ?Recommendation { get; set; }

            public string? XRayImagePath { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }

    
}
