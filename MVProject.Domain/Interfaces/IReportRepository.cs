using MVProject.Domain.Entities;

namespace MVProject.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<FundReport> GenerateFundReportAsync(FundReport fundReport);
        Task<GroupReport> GenerateGroupReportAsync(GroupReport groupReport);
        Task<FundReport?> GetFundReportAsync(Guid ID_FundReport);
        Task<GroupReport?> GetGroupReportAsync(Guid ID_GroupReport);
        Task<List<FundReport>> ListFundReportsAsync();
        Task<List<GroupReport>> ListGroupReportsAsync();
    }
}
