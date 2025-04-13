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

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task CreateUserAsync(User user)
        {
            var sql = "EXEC CreateUser @Email = {0}, @UserName = {1}, @HashPassword = {2}, @Phone = {3}, @Sex = {4}, @BirthDate = {5}, @UserAvatarPath = {6}";

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