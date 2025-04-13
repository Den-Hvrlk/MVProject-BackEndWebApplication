using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

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
