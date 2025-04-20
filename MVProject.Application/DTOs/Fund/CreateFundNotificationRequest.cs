

using System.ComponentModel.DataAnnotations;

namespace MVProject.Application.DTOs.Fund
{
    public record CreateFundNotificationRequest
    (
        [Required] string FundName,
        [Required] string CodeUSR,
        string FundDescription
    );
}
