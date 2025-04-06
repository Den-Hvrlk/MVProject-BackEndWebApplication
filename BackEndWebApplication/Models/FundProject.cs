using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class FundProject
{
    public Guid IdProject { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public DateOnly? ProjectCreateDate { get; set; }

    public Guid? IdFund { get; set; }

    public virtual ICollection<FundProjectImage> FundProjectImage { get; set; } = new List<FundProjectImage>();

    public virtual VolunteerFund? IdFundNavigation { get; set; }
}
