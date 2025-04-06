using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class Category
{
    public string IdCategory { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public virtual ICollection<Fundraising> IdFundraising { get; set; } = new List<Fundraising>();

    public virtual ICollection<MilitaryRequest> IdRequest { get; set; } = new List<MilitaryRequest>();
}
