﻿using MVProject.Application.DTOs;
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

            await _userRepository.RegisterUser(user);
            return "Ви успішно зареєстровані!";
        }

        public async Task<(bool Success, string? Error, LoginUserResponse? Data)> Login(LoginUserRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return (false, "Користувача з такою поштою не існує!", null);

            var isPasswordValid = _passwordHasher.VerifyPassword(user.HashPassword, request.Password);
            if (!isPasswordValid)
                return (false, "Невірний пароль!", null);

            var accessToken = _jwtProvider.GenerateAccessToken(user);
            var refreshToken = _jwtProvider.GenerateRefreshToken(user);

            int[] roles = user.ID_Roles.Select(r => r.ID_Role).ToArray();

            return (true, null, new LoginUserResponse(user.ID_User, roles, accessToken, refreshToken, "Ви успішно авторизувалися!", user.UserName));
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<UserProfileResponse?> GetUserProfileAsync(Guid userId)
        {
            var user = await _userRepository.GetProfileByIdAsync(userId);

            if (user == null)
                return null;

            return new UserProfileResponse
            {
                Id = user.ID_User,
                Email = user.Email,
                UserName = user.UserName,
                Roles = user.ID_Roles.Select(r => r.ID_Role).ToArray(),
                Sex = user.Sex,
                BirthDate = user.BirthDate,
                PhoneNumber = user.Phone,
                AvatarPath = user.UserAvatarPath
            };
        }

        public async Task<string> UpdateUserProfile(User user, UserProfileUpdateRequest userProfile)
        {
            var userProfilePatch = new UserProfilePatch
            {
                ID_User = userProfile.ID_User,
                Email = userProfile.Email ?? user.Email,
                UserName = userProfile.UserName ?? user.UserName,
                HashPassword = userProfile.HashPassword ?? user.HashPassword,
                Phone = userProfile.PhoneNumber ?? user.Phone,
                Sex = userProfile.Sex ?? user.Sex,
                BirthDate = userProfile.BirthDate ?? user.BirthDate,
                UserAvatarPath = userProfile.AvatarPath ?? user.UserAvatarPath
            };

            try
            {
                await _userRepository.UpdateUserProfile(userProfilePatch);
            }
            catch
            {
                return "Помилка при оновленні профілю!";
            }

            return "Профіль успішно оновлено!";
        }
    }
}
