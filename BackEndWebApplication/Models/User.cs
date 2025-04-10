using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class User
{
    public Guid ID_User { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? UserAvatarPath { get; set; }
}
