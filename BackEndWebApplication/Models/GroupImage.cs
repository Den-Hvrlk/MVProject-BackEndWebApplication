using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class GroupImage
{
    public string ID_Image { get; set; } = null!;

    public Guid ID_Group { get; set; }

    public string GroupImagePath { get; set; } = null!;

    public virtual MilitaryGroup ID_GroupNavigation { get; set; } = null!;
}
