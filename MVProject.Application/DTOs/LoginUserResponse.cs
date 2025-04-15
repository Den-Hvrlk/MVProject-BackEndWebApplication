using MVProject.API.MVProject.Domain.Entities;

namespace MVProject.Application.DTOs
{
    public record LoginUserResponse(Guid ID_User, int[] Roles, string AccessToken, string RefreshToken, string Message, string UserName);
}
