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

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _userService.CreateUserAsync(request);

            if (result == "Дана пошта вже зареєстрована!")
                return Conflict(result);

            return Ok(result);
        }
    }
}
