using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Domain.Entities
{
    public class UserProfilePatch
    {
        public Guid ID_User { get; set; }

        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? HashPassword { get; set; }
        public string? Phone { get; set; }
        public string? Sex { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? UserAvatarPath { get; set; }
    }
}
