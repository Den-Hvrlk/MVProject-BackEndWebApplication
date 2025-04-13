using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class User
{
    public Guid ID_User { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string? Phone { get; set; }

    public char? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? UserAvatarPath { get; set; }

    public virtual ICollection<VolunteerFund> ID_Funds { get; set; } = new List<VolunteerFund>();

    public virtual ICollection<MilitaryGroup> ID_Groups { get; set; } = new List<MilitaryGroup>();
}
