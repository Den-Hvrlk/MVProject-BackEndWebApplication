using MVProject.Application.DTOs.Fund;
using MVProject.Domain.Entities;

namespace MVProject.Application.Interfaces
{
    public interface IFundService
    {
        Task<string> RegisterFund(ResolveRegisterFundRequest volunteerFund);
        Task<string> CreateFundNotificationRequest(CreateFundNotificationRequest createFundRequest, Guid ID_User);
        Task<string> RejectRegisterFund(RejectRegisterFundRequest rejectRegister);
        Task<List<RegisterFundRequestDto>> GetAllRegisterFundRequests();
    }
}
