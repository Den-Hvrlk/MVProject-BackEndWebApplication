using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVProject.Application.DTOs.User;
using MVProject.Domain.Entities;

namespace MVProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(RegisterUserRequest request);
        Task<(bool Success, string? Error, LoginUserResponse? Data)> Login(LoginUserRequest request);
        Task<User?> GetUserByIdAsync(Guid ID_User);
        Task<UserProfileResponse?> GetUserProfileAsync(Guid ID_User);
        Task<string> UpdateUserProfile(User user, UserProfileUpdateRequest userProfile);
        Task<List<UserFundDto>> GetUserFunds(Guid ID_User);
        Task<List<UserGroupDto>> GetUserGroups(Guid ID_User);
    }
}
