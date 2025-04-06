using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class FundProjectImage
{
    public string IdImage { get; set; } = null!;

    public Guid IdProject { get; set; }

    public string ProjectImagePath { get; set; } = null!;

    public virtual FundProject IdProjectNavigation { get; set; } = null!;
}
