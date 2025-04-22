using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ReportForFundRecievedFund
{
    public Guid ID_Fund { get; set; }

    public DateOnly? FundrCreateDate { get; set; }

    public int? CompletedFundraisingCount { get; set; }

    public decimal TotalGoals { get; set; }

    public decimal TotalRaised { get; set; }
}
