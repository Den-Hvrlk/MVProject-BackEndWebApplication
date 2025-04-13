using MVProject.Application.Interfaces.Auth;

namespace MVProject.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // Use a secure hashing algorithm (e.g., PBKDF2, bcrypt, or Argon2)
            // Here, we'll use a simple hash for demonstration purposes
            using (var sha384 = System.Security.Cryptography.SHA384.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha384.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public bool VerifyPassword(string hashedPassword, string password) => hashedPassword == HashPassword(password);
    }
}
