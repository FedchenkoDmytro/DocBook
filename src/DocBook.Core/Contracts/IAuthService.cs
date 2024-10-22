using DocBook.Core.Models.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace DocBook.Core.Contracts
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> Register(RegisterUserDTO userDto);
        Task<AuthResponseDTO> Login(LoginDTO loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO request);
    }

}
