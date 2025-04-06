using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfCompleteRequest
{
    public Guid IdRequest { get; set; }

    public Guid IdFund { get; set; }

    public DateOnly? CompleteDate { get; set; }
}
