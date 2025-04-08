namespace BackEndWebApplication.Models.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public char? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
    }
}
