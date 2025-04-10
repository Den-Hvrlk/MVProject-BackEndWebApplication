using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class CompleteFundraising
{
    public Guid ID_Fundraising { get; set; }

    public Guid ID_Fund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public decimal FundsRaised { get; set; }

    public virtual VolunteerFund ID_FundNavigation { get; set; } = null!;

    public virtual Fundraising ID_FundraisingNavigation { get; set; } = null!;
}
