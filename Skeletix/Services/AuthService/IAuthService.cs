using Skeletix.Contracts.Auth;

namespace Skeletix.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
