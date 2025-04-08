using BackEndWebApplication.Data;
using BackEndWebApplication.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                return BadRequest("Дана пошта вже зареєстрована!");
            }

            char? sex = string.IsNullOrEmpty(request.Sex) ? null : request.Sex[0];

            var sql = "EXEC CreateUser @Email = {0}, @Phone = {1}, @Sex = {2}, @BirthDate = {3}, @UserAvatarPath = {4}";
            var result = _context.Database.ExecuteSqlRaw(
                sql,
                request.Email,
                request.Phone ?? null,
                request.Sex ?? null,
                request.BirthDate ?? null,
                request.AvatarPath ?? null
            );

            return Ok("Ви успішно зареєструвалися!");
        }

    }
}
