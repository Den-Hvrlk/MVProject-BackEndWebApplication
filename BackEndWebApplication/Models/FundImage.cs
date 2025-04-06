using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class FundImage
{
    public string IdImage { get; set; } = null!;

    public Guid IdFund { get; set; }

    public string FundImagePath { get; set; } = null!;

    public virtual VolunteerFund IdFundNavigation { get; set; } = null!;
}
