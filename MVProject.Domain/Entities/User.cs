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

    public string? Sex { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? UserAvatarPath { get; set; }

    public virtual ICollection<FundMember> FundMembers { get; set; } = new List<FundMember>();

    public virtual ICollection<MilitaryGrpMember> MilitaryGrpMembers { get; set; } = new List<MilitaryGrpMember>();

    public virtual ICollection<RegisterFundRequest> RegisterFundRequests { get; set; } = new List<RegisterFundRequest>();

    public virtual ICollection<RegisterGroupRequest> RegisterGroupRequests { get; set; } = new List<RegisterGroupRequest>();

    public virtual ICollection<Role> ID_Roles { get; set; } = new List<Role>();
}
