using BackEndWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndWebApplication.Controllers.UsersController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(string email, string? phone, string? sex, DateTime? birthDate, string? avatarPath)
        {
            var sql = "EXEC CreateUser @Email = {0}, @Phone = {1}, @Sex = {2}, @BirthDate = {3}, @UserAvatarPath = {4}";
            var result = _context.Database.ExecuteSqlRaw(
                sql,
                email,
                phone ?? (object)DBNull.Value,
                sex ?? (object)DBNull.Value,
                birthDate ?? (object)DBNull.Value,
                avatarPath ?? (object)DBNull.Value
            );

            return Ok("User successfully created.");
        }
    }
}
