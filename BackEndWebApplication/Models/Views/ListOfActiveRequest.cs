using System;
using System.Collections.Generic;

namespace BackEndWebApplication.Models.Views;

public partial class ListOfActiveRequest
{
    public Guid IdRequest { get; set; }

    public string RequestHeader { get; set; } = null!;

    public string RequestDescription { get; set; } = null!;

    public string? RequestImagePath { get; set; }

    public Guid IdGroup { get; set; }
}
