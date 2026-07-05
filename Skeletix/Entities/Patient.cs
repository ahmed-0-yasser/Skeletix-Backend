namespace Skeletix.Entities;

public class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    // Navigation
    public ICollection<MedicalFile> MedicalFiles { get; set; } = new List<MedicalFile>();
}

