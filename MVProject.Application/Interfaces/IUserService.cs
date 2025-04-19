using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVProject.Application.DTOs;
using MVProject.Domain.Entities;

namespace MVProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Register(RegisterUserRequest request);
        Task<(bool Success, string? Error, LoginUserResponse? Data)> Login(LoginUserRequest request);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<UserProfileResponse?> GetUserProfileAsync(Guid userId);
        Task<string> UpdateUserProfile(User user, UserProfileUpdateRequest userProfile);
    }
}
