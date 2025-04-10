using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfActiveRequest
{
    public Guid ID_Request { get; set; }

    public string RequestHeader { get; set; } = null!;

    public string RequestDescription { get; set; } = null!;

    public string? RequestImagePath { get; set; }

    public Guid ID_Group { get; set; }
}
