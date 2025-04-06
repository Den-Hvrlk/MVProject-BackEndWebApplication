using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class CompleteFundraising
{
    public Guid IdFundraising { get; set; }

    public Guid IdFund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public decimal FundsRaised { get; set; }

    public virtual VolunteerFund IdFundNavigation { get; set; } = null!;

    public virtual Fundraising IdFundraisingNavigation { get; set; } = null!;
}
