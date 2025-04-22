using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ReportForGroupRequest
{
    public Guid ID_Group { get; set; }

    public DateOnly? RequestCreateDate { get; set; }

    public int? AllRequestCount { get; set; }

    public int? CompletedRequestCount { get; set; }

    public int? IncompleteRequestCount { get; set; }
}
