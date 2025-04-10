using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfCompleteFundraising
{
    public Guid ID_Fundraising { get; set; }

    public Guid ID_Fund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public decimal FundsRaised { get; set; }
}
