using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class GroupReport
{
    public Guid ID_GroupReport { get; set; }

    public int FundraisingCount { get; set; }

    public int ClosedFundraisingCount { get; set; }

    public decimal GoalToBeRecieved { get; set; }

    public decimal FundsReceived { get; set; }

    public int AllRequestCount { get; set; }

    public int? CompletedRequestCount { get; set; }

    public int? IncompleteRequestCount { get; set; }

    public DateOnly Period { get; set; }

    public Guid ID_Group { get; set; }

    public virtual MilitaryGroup ID_GroupNavigation { get; set; } = null!;
}
