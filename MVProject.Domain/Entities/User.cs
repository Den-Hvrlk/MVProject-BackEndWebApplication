using MVProject.API.MVProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVProject.Domain.Entities;

public partial class User
{
    private User(string email, string userName, string hashPassword)
    {
        Email = email;
        UserName = userName;
        HashPassword = hashPassword;
    }

    public Guid ID_User { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? UserAvatarPath { get; set; }

    public virtual ICollection<VolunteerFund> ID_Funds { get; set; } = new List<VolunteerFund>();

    public virtual ICollection<MilitaryGroup> ID_Groups { get; set; } = new List<MilitaryGroup>();

    public virtual ICollection<Role> ID_Roles { get; set; } = new List<Role>();

    public static User Create(string Email, string UserName, string HashPassword)
    {
        return new User(Email, UserName, HashPassword);
    }
}
