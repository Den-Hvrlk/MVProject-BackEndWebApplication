using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfCompleteFundraising
{
    public Guid IdFundraising { get; set; }

    public Guid IdFund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public decimal FundsRaised { get; set; }
}
