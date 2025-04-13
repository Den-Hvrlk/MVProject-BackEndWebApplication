using MVProject.Application.DTOs;
using MVProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndWebApplication.Controllers.UsersController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var result = await _userService.Register(request);

            if (result == "Дана пошта вже зареєстрована!")
                return Conflict(result);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var (success, error, data) = await _userService.Login(request);

            if (!success)
                return Unauthorized(error);

            Response.Cookies.Append("tasty-cookies", data?.Token!, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddMinutes(15)
            });

            return Ok(data);
        }
    }
}
