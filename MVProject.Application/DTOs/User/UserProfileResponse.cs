using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.User
{
    public class UserProfileResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int[] Roles { get; set; } = Array.Empty<int>();
        public string? Sex { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarPath { get; set; }
        public List<UserFundDto> UserFunds { get; set; } = new List<UserFundDto>();
        public List<UserGroupDto> UserGroups { get; set; } = new List<UserGroupDto>();
    }
}
