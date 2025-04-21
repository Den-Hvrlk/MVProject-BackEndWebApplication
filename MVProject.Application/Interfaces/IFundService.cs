using MVProject.Application.DTOs.Fund;
using MVProject.Domain.Entities;

namespace MVProject.Application.Interfaces
{
    public interface IFundService
    {
        Task<string> RegisterFund(Guid ID_RegisterFundRequest);
        Task<string> CreateFundNotificationRequest(CreateFundNotificationRequest createFundRequest, Guid ID_User);
        Task<string> RejectRegisterFund(Guid ID_RegisterFundRequest);
        Task<List<RegisterFundRequestDto>> GetAllRegisterFundRequests();
    }
}
