using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class MilitaryRequest
{
    public Guid ID_Request { get; set; }

    public DateOnly? RequestCreateDate { get; set; }

    public string RequestHeader { get; set; } = null!;

    public string RequestDescription { get; set; } = null!;

    public string? RequestImagePath { get; set; }

    public Guid ID_Group { get; set; }

    public virtual ICollection<CompleteRequest> CompleteRequests { get; set; } = new List<CompleteRequest>();

    public virtual MilitaryGroup ID_GroupNavigation { get; set; } = null!;

    public virtual ICollection<Category> ID_Categories { get; set; } = new List<Category>();
}
