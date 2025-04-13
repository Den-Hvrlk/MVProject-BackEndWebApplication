using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces.Users;
using MVProject.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace MVProject.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower()) ?? null!;
        }

        public async Task AddAsync(User user)
        {
            var sql = "EXEC CreateUser @Email = {0}, @UserName = {1}, @HashPassword = {2}";

            await _context.Database.ExecuteSqlRawAsync(
                sql,
                user.Email,
                user.UserName,
                user.HashPassword,
                user.Phone ?? null!,
                user.Sex.HasValue ? user.Sex.Value : (char?)null!,
                user.BirthDate ?? null!,
                user.UserAvatarPath ?? null!
            );
        }
    }
}