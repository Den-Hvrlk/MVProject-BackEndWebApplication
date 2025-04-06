using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class VolunteerFund
{
    public Guid IdFund { get; set; }

    public string FundName { get; set; } = null!;

    public string? FundDescription { get; set; }

    public DateOnly? FundCreateDate { get; set; }

    public virtual ICollection<CompleteFundraising> CompleteFundraising { get; set; } = new List<CompleteFundraising>();

    public virtual ICollection<CompleteRequest> CompleteRequest { get; set; } = new List<CompleteRequest>();

    public virtual ICollection<FundImage> FundImage { get; set; } = new List<FundImage>();

    public virtual ICollection<FundProject> FundProject { get; set; } = new List<FundProject>();

    public virtual ICollection<Fundraising> IdFundraising { get; set; } = new List<Fundraising>();

    public virtual ICollection<User> IdUser { get; set; } = new List<User>();
}
