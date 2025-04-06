using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class Fundraising
{
    public Guid IdFundraising { get; set; }

    public decimal FundrGoal { get; set; }

    public string FundrHeader { get; set; } = null!;

    public string FundrDescription { get; set; } = null!;

    public DateOnly? FundrCreateDate { get; set; }

    public string? FundrImagePath { get; set; }

    public Guid IdGroup { get; set; }

    public virtual ICollection<CompleteFundraising> CompleteFundraising { get; set; } = new List<CompleteFundraising>();

    public virtual MilitaryGroup IdGroupNavigation { get; set; } = null!;

    public virtual ICollection<Category> IdCategory { get; set; } = new List<Category>();

    public virtual ICollection<VolunteerFund> IdFund { get; set; } = new List<VolunteerFund>();
}
