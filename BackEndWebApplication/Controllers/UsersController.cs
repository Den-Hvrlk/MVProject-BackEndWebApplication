﻿using MVProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MVProject.Application.DTOs.User;

namespace MVProject.API.Controllers
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

            Response.Cookies.Append("tasty-cookies", data?.RefreshToken!, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            return Ok(new
            {
                Id = data?.ID_User,
                data?.Roles,
                data?.AccessToken,
                data?.Message,
                data?.UserName,
                data?.UserFunds,
                data?.UserGroups
            });
        }

        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }

            var user = await _userService.GetUserProfileAsync(userId);
            if (user == null)
                return NotFound("Користувача не знайдено.");

            return Ok(user);
        }

        [HttpPut("UpdateUserProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileUpdateRequest newUserProfile)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("Користувача не знайдено.");

            var result = await _userService.UpdateUserProfile(user, newUserProfile);
            if (result == "Помилка при оновленні профілю!")
                return StatusCode(500, "Виникла помилка при оновленні профілю. Спробуйте пізніше.");

            return Ok(result);
        }
    }
}
