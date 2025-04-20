using MVProject.Domain.Entities;

namespace MVProject.Application.DTOs.User
{
    public record LoginUserResponse(Guid ID_User, int[] Roles, string AccessToken, string RefreshToken, string Message, string UserName);
}
