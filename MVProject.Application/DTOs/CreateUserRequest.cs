namespace MVProject.Application.DTOs
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
    }
}