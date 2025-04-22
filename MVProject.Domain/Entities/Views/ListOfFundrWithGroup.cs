using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class ListOfFundrWithGroup
{
    public Guid ID_Fundraising { get; set; }

    public decimal FundrGoal { get; set; }

    public string FundrDescription { get; set; } = null!;

    public DateOnly? FundrCreateDate { get; set; }

    public Guid ID_Group { get; set; }

    public decimal FundsRaised { get; set; }

    public DateOnly? CompleteDate { get; set; }
}
