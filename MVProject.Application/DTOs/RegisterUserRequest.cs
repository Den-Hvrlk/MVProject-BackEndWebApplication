using System.ComponentModel.DataAnnotations;

namespace MVProject.Application.DTOs;

public record RegisterUserRequest
(
    [Required] string Email,
    [Required] string UserName,
    [Required] string Password,
    string? Phone,
    string? Sex,
    DateTime? BirthDate,
    string? AvatarPath
);