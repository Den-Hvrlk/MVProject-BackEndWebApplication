using MVProject.Application.DTOs.Fund;

namespace MVProject.Application.Interfaces
{
    public interface IFundService
    {
        Task<string> RegisterFund(ResolveRegisterFundRequest volunteerFund);
        Task<string> CreateFundNotificationRequest(CreateFundNotificationRequest createFundRequest, Guid ID_User);
        Task<string> RejectRegisterFund(RejectRegisterFundRequest rejectRegister);
        //Task<string> GetFundById(int id);
        //Task<string> GetAllFunds();
        //Task<string> UpdateFund(int id, object volunteerFund);
        //Task<string> DeleteFund(int id);
    }
}
