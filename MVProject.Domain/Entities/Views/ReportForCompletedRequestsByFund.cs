using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ReportForCompletedRequestsByFund
{
    public Guid ID_Fund { get; set; }

    public DateOnly? RequestCreateDate { get; set; }

    public int? CompletedRequestCount { get; set; }
}
