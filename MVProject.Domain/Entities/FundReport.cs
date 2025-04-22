using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class FundReport
{
    public Guid ID_FundReport { get; set; }

    public int CompletedRequestsCount { get; set; }

    public int CompletedFundraisingCount { get; set; }

    public decimal TotalGoals { get; set; }

    public decimal TotalRaised { get; set; }

    public DateOnly Period { get; set; }

    public Guid ID_Fund { get; set; }

    public virtual VolunteerFund ID_FundNavigation { get; set; } = null!;
}
