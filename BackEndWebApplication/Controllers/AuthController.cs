using Microsoft.AspNetCore.Mvc;
using MVProject.Application.Interfaces.Auth;
using MVProject.Application.Interfaces;
using System.Security.Claims;

namespace MVProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserService _userService;
        public AuthController(IJwtProvider jwtProvider, IUserService userService)
        {
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["tasty-cookies"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized("Refresh token is missing");

            var principal = _jwtProvider.GetPrincipalFromToken(refreshToken);
            if (principal == null || !principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
                return Unauthorized("Invalid refresh token");

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var user = await _userService.GetUserByIdAsync(Guid.Parse(userId));
            if (user == null)
                return Unauthorized("Користувача не знайдено");

            var userFunds = await _userService.GetUserFunds(user.ID_User);
            var userGroups = await _userService.GetUserGroups(user.ID_User);

            var newAccessToken = _jwtProvider.GenerateAccessToken(user);

            return Ok(new
            {
                id = user.ID_User,
                accessToken = newAccessToken,
                email = user.Email,
                roles = user.ID_Roles.Select(r => r.ID_Role).ToArray(),
                userName = user.UserName,
                userFunds,
                userGroups,
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("tasty-cookies", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return Ok(new { message = "Ви успішно вийшли" });
        }
    }
}
