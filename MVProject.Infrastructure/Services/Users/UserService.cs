using MVProject.Application.DTOs;
using MVProject.Application.Interfaces;
using MVProject.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using MVProject.Domain.Interfaces.Users;
using MVProject.Domain.Entities;

namespace MVProject.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUserAsync(CreateUserRequest request)
        {
            var emailExists = await _userRepository.EmailExistsAsync(request.Email);
            if (emailExists)
                return "Дана пошта вже зареєстрована!";

            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                HashPassword = request.Password,
                Phone = null,
                Sex = null,
                BirthDate = null,
                UserAvatarPath = null
            };

            await _userRepository.CreateUserAsync(user);
            return "Ви успішно зареєстровані!";
        }
    }
}
