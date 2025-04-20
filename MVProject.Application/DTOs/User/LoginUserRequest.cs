using System.ComponentModel.DataAnnotations;

namespace MVProject.Application.DTOs.User;

public record LoginUserRequest
(
    [Required] string Email,
    [Required] string Password
);
