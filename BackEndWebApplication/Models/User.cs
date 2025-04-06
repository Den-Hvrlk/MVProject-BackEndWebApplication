using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class User
{
    public Guid IdUser { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? UserAvatarPath { get; set; }

    public virtual ICollection<VolunteerFund> UserFunds { get; set; } = new List<VolunteerFund>();

    public virtual MilitaryGroup UserGroup { get; set; } = new MilitaryGroup();
}
