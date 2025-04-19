using MVProject.Domain.Entities;

namespace MVProject.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task RegisterUser(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetProfileByIdAsync(Guid userId);
        Task UpdateUserProfile(UserProfilePatch userProfilePatch);
    }
}
