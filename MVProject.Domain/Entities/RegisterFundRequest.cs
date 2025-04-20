using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class RegisterFundRequest
{
    public Guid ID_RegisterFundRequest { get; set; }

    public Guid ID_User { get; set; }

    public string FundName { get; set; } = null!;

    public string CodeUSR { get; set; } = null!;

    public string? FundDescription { get; set; }

    public DateOnly? RegisterFundRequestDate { get; set; }

    public bool? RegisterFundRequestStatus { get; set; }

    public virtual User ID_UserNavigation { get; set; } = null!;
}
