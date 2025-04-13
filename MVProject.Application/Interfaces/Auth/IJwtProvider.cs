using MVProject.Domain.Entities;
using System.Security.Claims;

namespace MVProject.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken(User user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
