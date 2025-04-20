using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class MilitaryGrpMember
{
    public Guid ID_User { get; set; }

    public Guid ID_Group { get; set; }

    public bool IsAdmin { get; set; }

    public virtual MilitaryGroup ID_GroupNavigation { get; set; } = null!;

    public virtual User ID_UserNavigation { get; set; } = null!;
}
