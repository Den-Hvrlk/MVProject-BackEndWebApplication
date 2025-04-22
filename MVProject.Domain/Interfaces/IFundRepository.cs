using MVProject.Domain.Entities;

namespace MVProject.Domain.Interfaces
{
    public interface IFundRepository
    {
        public Task<string> RegisterFund(Guid ID_RegisterFundRequest, Guid ID_User);
        public Task<VolunteerFund?> GetByCodeAsync(string code);
        public Task<string> CreateFundNotificationRequest(RegisterFundRequest registerFundRequest);
        public Task<RegisterFundRequest?> GetRegisterRequestByIdAsync(Guid ID_RegisterFundRequest);
        public Task<string> RejectFundNotificationRequest(Guid ID_RegisterFundRequest);
        public Task<List<RegisterFundRequest>> GetAllRegisterFundRequests();
    }
}
