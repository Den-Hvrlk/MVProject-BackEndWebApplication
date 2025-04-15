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

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.ID_Roles)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
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
                user.Sex ?? null!,
                user.BirthDate ?? null!,
                user.UserAvatarPath ?? null!
            );
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.ID_User == id);
        }
    }
}