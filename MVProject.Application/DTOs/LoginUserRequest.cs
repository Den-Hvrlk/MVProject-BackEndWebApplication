using System.ComponentModel.DataAnnotations;

namespace MVProject.Application.DTOs;

public record LoginUserRequest
(
    [Required] string Email,
    [Required] string Password
);
