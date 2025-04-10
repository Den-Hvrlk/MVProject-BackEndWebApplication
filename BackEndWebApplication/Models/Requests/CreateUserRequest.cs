namespace BackEndWebApplication.Models.Requests
{
    public class CreateUserRequest
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarPath { get; set; }
    }
}
