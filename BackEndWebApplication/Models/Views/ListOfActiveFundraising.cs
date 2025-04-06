using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfActiveFundraising
{
    public Guid IdFundraising { get; set; }

    public string FundrHeader { get; set; } = null!;

    public decimal FundrGoal { get; set; }

    public string FundrDescription { get; set; } = null!;

    public string? FundrImagePath { get; set; }

    public Guid IdGroup { get; set; }
}
