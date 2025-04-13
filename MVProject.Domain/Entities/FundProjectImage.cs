using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class FundProjectImage
{
    public string ID_Image { get; set; } = null!;

    public Guid ID_Project { get; set; }

    public string ProjectImagePath { get; set; } = null!;

    public virtual FundProject ID_ProjectNavigation { get; set; } = null!;
}
