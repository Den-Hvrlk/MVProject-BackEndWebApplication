using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class FundMember
{
    public Guid ID_User { get; set; }

    public Guid ID_Fund { get; set; }

    public bool IsAdmin { get; set; }

    public virtual VolunteerFund ID_FundNavigation { get; set; } = null!;

    public virtual User ID_UserNavigation { get; set; } = null!;
}
