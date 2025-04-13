using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class Fundraising
{
    public Guid ID_Fundraising { get; set; }

    public decimal FundrGoal { get; set; }

    public string FundrHeader { get; set; } = null!;

    public string FundrDescription { get; set; } = null!;

    public DateOnly? FundrCreateDate { get; set; }

    public string? FundrImagePath { get; set; }

    public Guid ID_Group { get; set; }

    public virtual ICollection<CompleteFundraising> CompleteFundraisings { get; set; } = new List<CompleteFundraising>();

    public virtual MilitaryGroup ID_GroupNavigation { get; set; } = null!;

    public virtual ICollection<Category> ID_Categories { get; set; } = new List<Category>();

    public virtual ICollection<VolunteerFund> ID_Funds { get; set; } = new List<VolunteerFund>();
}
