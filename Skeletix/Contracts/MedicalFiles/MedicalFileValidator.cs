using FluentValidation;
using Microsoft.AspNetCore.Http;
namespace Skeletix.Contracts.MedicalFiles;

public class MedicalFileValidator: AbstractValidator<MedicalFileRequest> 

    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".dcm" };
        private const long MaxFileSize = 10 * 1024 * 1024; 

        public MedicalFileValidator()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required.")
                .Must(f => f!.Length > 0).WithMessage("File cannot be empty.")
                .Must(f => AllowedExtensions.Contains(Path.GetExtension(f!.FileName).ToLower()))
                .WithMessage("File type not allowed.")
                .Must(f => f!.Length <= MaxFileSize)
                .WithMessage($"File size cannot exceed {MaxFileSize / (1024 * 1024)} MB.");
            RuleFor(x => x.FileType)
                .NotEmpty().WithMessage("FileType is required.");

           
        }
    }




