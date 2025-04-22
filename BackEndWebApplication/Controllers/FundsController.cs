using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVProject.Application.Interfaces;
using MVProject.Application.DTOs.Fund;
using System.Security.Claims;


namespace MVProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly IFundService _fundService;
        private readonly IUserService _userService;

        public FundsController(IFundService fundService, IUserService userService)
        {
            _fundService = fundService;
            _userService = userService;
        }

        [HttpPost("Resolve-register/{id}")]
        [Authorize]
        public async Task<IActionResult> ResolveRegister([FromRoute] Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid ID_User = Guid.Empty;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out ID_User))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }

            var permissionsCheck = await _userService.GetUserByIdAsync(ID_User);
            if(!permissionsCheck!.ID_Roles.Any(role => role.ID_Role == 1001))
            {
                return StatusCode(403, "Недостатньо прав для виконання цієї дії.");
            }

            var result = await _fundService.RegisterFund(id);
            return Ok(result);
        }

        [HttpPut("Reject-register/{id}")]
        [Authorize]
        public async Task<IActionResult> RejectRegister([FromRoute] Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid ID_User = Guid.Empty;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out ID_User))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }

            var permissionsCheck = await _userService.GetUserByIdAsync(ID_User);
            if (!permissionsCheck!.ID_Roles.Any(role => role.ID_Role == 1001))
            {
                return Forbid("Недостатньо прав для виконання цієї дії.");
            }

            var result = await _fundService.RejectRegisterFund(id);
            if(result == "Виникла помилка при відхиленні запиту на створення фонду.")
                return StatusCode(500, result);

            return Ok(result);
        }

        [HttpPost("Create-request")]
        [Authorize]
        public async Task<IActionResult> CreateRequest([FromBody] CreateFundNotificationRequest createFundRequest)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid ID_User = Guid.Empty;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out ID_User))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }

            var result = await _fundService.CreateFundNotificationRequest(createFundRequest, ID_User);

            if(result == "Виникла помилка при відправці запиту на створення фонду.")
                return StatusCode(500, result);
            else if(result == "Заданий код ЄДРПОУ вже зареєстрований!")
                return StatusCode(409, result);

            return Ok(result);
        }

        [HttpGet("Get-requests")]
        [Authorize]
        public async Task<IActionResult> GetRequests()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid ID_User = Guid.Empty;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out ID_User))
            {
                return Unauthorized("Недійсний токен або відсутній ідентифікатор користувача.");
            }

            var permissionsCheck = await _userService.GetUserByIdAsync(ID_User);
            if (!permissionsCheck!.ID_Roles.Any(role => role.ID_Role == 1001))
            {
                return Forbid("Недостатньо прав для виконання цієї дії.");
            }

            var requests = await _fundService.GetAllRegisterFundRequests();

            if (requests == null || requests.Count == 0)
                return Ok("Запити на реєстрацію фонду не знайдені.");

            return Ok(requests);
        }
    }
}
