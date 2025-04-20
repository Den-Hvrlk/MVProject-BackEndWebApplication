using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class RegisterGroupRequest
{
    public Guid ID_RegisterGroupRequest { get; set; }

    public Guid ID_User { get; set; }

    public string GroupName { get; set; } = null!;

    public string? GroupDescription { get; set; }

    public DateOnly? RegisterGroupRequestDate { get; set; }

    public bool? RegisterGroupRequestStatus { get; set; }

    public virtual User ID_UserNavigation { get; set; } = null!;
}
