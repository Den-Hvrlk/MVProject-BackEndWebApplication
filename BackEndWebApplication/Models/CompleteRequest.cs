using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class CompleteRequest
{
    public Guid IdRequest { get; set; }

    public Guid IdFund { get; set; }

    public DateOnly? CompleteDate { get; set; }

    public virtual VolunteerFund IdFundNavigation { get; set; } = null!;

    public virtual MilitaryRequest IdRequestNavigation { get; set; } = null!;
}
