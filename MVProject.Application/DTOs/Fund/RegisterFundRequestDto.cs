namespace MVProject.Application.DTOs.Fund;

public class RegisterFundRequestDto
{
    public Guid ID_RegisterFundRequest { get; set; }
    public Guid ID_User { get; set; }
    public string FundName { get; set; } = string.Empty;
    public string CodeUSR { get; set; } = string.Empty;
    public string FundDescription { get; set; } = string.Empty;
    public DateOnly? RegisterFundRequestDate { get; set; }
    public bool? RegisterFundRequestStatus { get; set; }
    public string UserName { get; set; } = string.Empty;
}
