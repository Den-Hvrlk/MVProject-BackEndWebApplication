using MVProject.Domain.Entities;

namespace MVProject.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
