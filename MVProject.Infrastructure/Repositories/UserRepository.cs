using MVProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using MVProject.Infrastructure.Db;
using MVProject.Domain.Interfaces;

namespace MVProject.Infrastructure.Repositories
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
                new SqlParameter("@Email", (object?)userProfilePatch.Email == null || (object?)userProfilePatch.Email == "" ? DBNull.Value : (object?)userProfilePatch.Email),
                new SqlParameter("@UserName", (object?)userProfilePatch.UserName == null || (object?)userProfilePatch.UserName == "" ? DBNull.Value : (object?)userProfilePatch.UserName),
                new SqlParameter("@HashPassword", (object?)userProfilePatch.HashPassword == null || (object?)userProfilePatch.HashPassword == "" ? DBNull.Value : (object?)userProfilePatch.HashPassword),
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

        public async Task<ICollection<FundMember>> GetUserFunds(Guid id)
        {
            return await _context.FundMembers
                .AsNoTracking()
                .Include(f => f.ID_FundNavigation)
                .Include(f => f.ID_UserNavigation)
                .Where(f => f.ID_User == id)
                .ToListAsync();
        }

        public async Task<ICollection<MilitaryGrpMember>> GetUserGroups(Guid id)
        {
            return await _context.MilitaryGrpMembers
                .AsNoTracking()
                .Include(g => g.ID_GroupNavigation)
                .Include(g => g.ID_UserNavigation)
                .Where(g => g.ID_User == id)
                .ToListAsync();
        }
    }
}