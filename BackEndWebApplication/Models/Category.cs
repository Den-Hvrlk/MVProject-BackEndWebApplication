using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class Category
{
    public string ID_Category { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public virtual ICollection<Fundraising> ID_Fundraisings { get; set; } = new List<Fundraising>();

    public virtual ICollection<MilitaryRequest> ID_Requests { get; set; } = new List<MilitaryRequest>();
}
