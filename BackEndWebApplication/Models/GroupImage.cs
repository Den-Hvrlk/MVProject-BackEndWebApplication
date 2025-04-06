using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class GroupImage
{
    public string IdImage { get; set; } = null!;

    public Guid IdGroup { get; set; }

    public string GroupImagePath { get; set; } = null!;

    public virtual MilitaryGroup IdGroupNavigation { get; set; } = null!;
}
