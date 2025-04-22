using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ReportForGroupRecievedFund
{
    public Guid ID_Group { get; set; }

    public DateOnly? FundrCreateDate { get; set; }

    public int? FundraisingCount { get; set; }

    public int? ClosedFundraisingCount { get; set; }

    public decimal GoalToBeRecieved { get; set; }

    public decimal FundsReceived { get; set; }
}
