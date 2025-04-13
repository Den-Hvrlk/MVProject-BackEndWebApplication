using MVProject.Domain.Entities;

namespace MVProject.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
    }
}
