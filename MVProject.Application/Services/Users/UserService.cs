using MVProject.Application.DTOs;
using MVProject.Application.Interfaces;
using MVProject.Domain.Interfaces.Users;
using MVProject.Domain.Entities;
using MVProject.Application.Interfaces.Auth;

namespace MVProject.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Register(RegisterUserRequest request)
        {
            var userExists = await _userRepository.GetByEmailAsync(request.Email);
            if (userExists != null)
                return "Дана пошта вже зареєстрована!";

            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var user = User.Create(
                request.Email,
                request.UserName,
                passwordHash
            );

            await _userRepository.AddAsync(user);
            return "Ви успішно зареєстровані!";
        }

        public async Task<(bool Success, string? Error, LoginUserResponse? Data)> Login(LoginUserRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return (false, "Користувача з такою поштою не існує!", null);

            Console.Write(user.HashPassword, request.Password);
            var isPasswordValid = _passwordHasher.VerifyPassword(user.HashPassword, request.Password);
            if (!isPasswordValid)
                return (false, "Невірний пароль!", null);

            var token = _jwtProvider.GenerateToken(user);

            return (true, null, new LoginUserResponse(token, "Ви успішно авторизувалися!"));
        }
    }
}
