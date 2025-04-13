using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class MilitaryGroup
{
    public Guid ID_Group { get; set; }

    public string GroupName { get; set; } = null!;

    public string? GroupDescription { get; set; }

    public DateOnly? CreateGroupDate { get; set; }

    public virtual ICollection<Fundraising> Fundraisings { get; set; } = new List<Fundraising>();

    public virtual ICollection<GroupImage> GroupImages { get; set; } = new List<GroupImage>();

    public virtual ICollection<MilitaryRequest> MilitaryRequests { get; set; } = new List<MilitaryRequest>();

    public virtual ICollection<User> ID_Users { get; set; } = new List<User>();
}
