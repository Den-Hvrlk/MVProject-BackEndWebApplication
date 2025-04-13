using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities.Views;

public partial class ListOfCompleteRequest
{
    public Guid ID_Request { get; set; }

    public Guid ID_Fund { get; set; }

    public DateOnly? CompleteDate { get; set; }
}
