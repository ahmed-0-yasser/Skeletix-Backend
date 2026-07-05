using Microsoft.IdentityModel.Tokens;
using Skeletix.Contracts.Auth;
using Skeletix.Entities;
using Skeletix.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Skeletix.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            if (await _context.Patients.AnyAsync(p => p.Email == dto.Email))
                throw new Exception("User with this email already exists.");

            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth, // ? ???? ?? Age
                CreatedAt = DateTime.UtcNow
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return GenerateToken(patient);
        }

        public async Task<string> Login(LoginDto dto)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == dto.Email);

            if (patient == null || !BCrypt.Net.BCrypt.Verify(dto.Password, patient.PasswordHash))
                throw new Exception("Invalid email or password");

            return GenerateToken(patient);
        }

        private string GenerateToken(Patient patient)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, patient.PatientId.ToString()),
                new Claim(ClaimTypes.Name, $"{patient.FirstName} {patient.LastName}"),
                new Claim(ClaimTypes.Email, patient.Email)
            };

            var jwtKey = _config["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key is missing from configuration.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}