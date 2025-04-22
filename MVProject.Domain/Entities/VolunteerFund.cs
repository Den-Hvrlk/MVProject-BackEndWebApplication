using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class VolunteerFund
{
    public Guid ID_Fund { get; set; }

    public string FundName { get; set; } = null!;

    public string CodeUSR { get; set; } = null!;

    public string? FundDescription { get; set; }

    public DateOnly? FundCreateDate { get; set; }

    public virtual ICollection<CompleteFundraising> CompleteFundraisings { get; set; } = new List<CompleteFundraising>();

    public virtual ICollection<CompleteRequest> CompleteRequests { get; set; } = new List<CompleteRequest>();

    public virtual ICollection<FundImage> FundImages { get; set; } = new List<FundImage>();

    public virtual ICollection<FundMember> FundMembers { get; set; } = new List<FundMember>();

    public virtual ICollection<FundProject> FundProjects { get; set; } = new List<FundProject>();

    public virtual ICollection<FundReport> FundReports { get; set; } = new List<FundReport>();

    public virtual ICollection<Fundraising> ID_Fundraisings { get; set; } = new List<Fundraising>();
}
