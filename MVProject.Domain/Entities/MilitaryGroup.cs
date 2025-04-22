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

    public virtual ICollection<GroupReport> GroupReports { get; set; } = new List<GroupReport>();

    public virtual ICollection<MilitaryGrpMember> MilitaryGrpMembers { get; set; } = new List<MilitaryGrpMember>();

    public virtual ICollection<MilitaryRequest> MilitaryRequests { get; set; } = new List<MilitaryRequest>();
}
