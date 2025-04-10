using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class CompleteRequest
{
    public Guid ID_Request { get; set; }

    public Guid ID_Fund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public virtual VolunteerFund ID_FundNavigation { get; set; } = null!;

    public virtual MilitaryRequest ID_RequestNavigation { get; set; } = null!;
}
