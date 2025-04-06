using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class MilitaryGroup
{
    public Guid IdGroup { get; set; }

    public string GroupName { get; set; } = null!;

    public string? GroupDescription { get; set; }

    public DateOnly? CreateGroupDate { get; set; }

    public virtual ICollection<Fundraising> Fundraising { get; set; } = new List<Fundraising>();

    public virtual ICollection<GroupImage> GroupImage { get; set; } = new List<GroupImage>();

    public virtual ICollection<MilitaryRequest> MilitaryRequest { get; set; } = new List<MilitaryRequest>();

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
