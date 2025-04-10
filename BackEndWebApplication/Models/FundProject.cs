using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class FundProject
{
    public Guid ID_Project { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public DateOnly? ProjectCreateDate { get; set; }

    public Guid? ID_Fund { get; set; }

    public virtual ICollection<FundProjectImage> FundProjectImages { get; set; } = new List<FundProjectImage>();

    public virtual VolunteerFund? ID_FundNavigation { get; set; }
}
