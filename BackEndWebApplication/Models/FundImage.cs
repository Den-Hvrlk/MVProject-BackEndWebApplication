using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class FundImage
{
    public string ID_Image { get; set; } = null!;

    public Guid ID_Fund { get; set; }

    public string FundImagePath { get; set; } = null!;

    public virtual VolunteerFund ID_FundNavigation { get; set; } = null!;
}
