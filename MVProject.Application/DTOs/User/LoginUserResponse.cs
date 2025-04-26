using MVProject.Domain.Entities;

namespace MVProject.Application.DTOs.User
{
    public record LoginUserResponse(
        Guid ID_User, int[] Roles, string AccessToken, string RefreshToken, string Message, string UserName,
        ICollection<UserFundDto> UserFunds, ICollection<UserGroupDto> UserGroups
    );

    public record UserFundDto(Guid FundId, string FundName, string CodeUSR);
    public record UserGroupDto(Guid GroupId, string GroupName);
}
