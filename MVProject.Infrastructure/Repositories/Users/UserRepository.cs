using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces.Users;
using MVProject.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using MVProject.Application.DTOs;
using Microsoft.Data.SqlClient;

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

        public async Task RegisterUser(User user)
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
            return await _context.Users
                        .Include(u => u.ID_Roles)
                        .FirstOrDefaultAsync(u => u.ID_User == id);
        }

        public async Task<User?> GetProfileByIdAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.ID_Roles)
                .FirstOrDefaultAsync(u => u.ID_User == userId);

            if (user == null) return null;
            return user;
        }

        public async Task UpdateUserProfile(UserProfilePatch userProfilePatch)
        {
            var sql = @"
            EXEC UpdateUser 
                @ID_User = @ID_User,
                @Email = @Email,
                @UserName = @UserName,
                @HashPassword = @HashPassword,
                @Phone = @Phone,
                @Sex = @Sex,
                @BirthDate = @BirthDate,
                @UserAvatarPath = @UserAvatarPath";

            var parameters = new[]
            {
                new SqlParameter("@ID_User", userProfilePatch.ID_User),
                new SqlParameter("@Email", (object?)userProfilePatch.Email ?? DBNull.Value),
                new SqlParameter("@UserName", (object?)userProfilePatch.UserName ?? DBNull.Value),
                new SqlParameter("@HashPassword", (object?)userProfilePatch.HashPassword ?? DBNull.Value),
                new SqlParameter("@Phone", (object?)userProfilePatch.Phone ?? DBNull.Value),
                new SqlParameter("@Sex", (object?)userProfilePatch.Sex ?? DBNull.Value),
                new SqlParameter("@BirthDate", (object?)userProfilePatch.BirthDate ?? DBNull.Value),
                new SqlParameter("@UserAvatarPath", (object?)userProfilePatch.UserAvatarPath ?? DBNull.Value),
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Виникла помилка при оновлені користувача в БД", ex);
            }
        }
    }
}