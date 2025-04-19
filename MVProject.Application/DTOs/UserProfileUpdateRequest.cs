﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs
{
    public class UserProfileUpdateRequest
    {
        public Guid ID_User { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? HashPassword { get; set; }
        public string? Sex { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarPath { get; set; }
    }
}
