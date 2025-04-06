using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models;

public partial class MilitaryRequest
{
    public Guid IdRequest { get; set; }

    public DateOnly? RequestCreateDate { get; set; }

    public string RequestHeader { get; set; } = null!;

    public string RequestDescription { get; set; } = null!;

    public string? RequestImagePath { get; set; }

    public Guid IdGroup { get; set; }

    public virtual ICollection<CompleteRequest> CompleteRequest { get; set; } = new List<CompleteRequest>();

    public virtual MilitaryGroup IdGroupNavigation { get; set; } = null!;

    public virtual ICollection<Category> IdCategory { get; set; } = new List<Category>();
}
