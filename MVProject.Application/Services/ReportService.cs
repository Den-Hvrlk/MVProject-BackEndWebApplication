using MVProject.Application.DTOs.Report;
using MVProject.Application.Interfaces;
using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces;

namespace MVProject.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository) 
        {
            _reportRepository = reportRepository;
        }

        public async Task<FundReport> GenerateFundReportAsync(FundReportRequest fundReportRequest)
        {
            FundReport fundReport = new FundReport
            {
                ID_Fund = fundReportRequest.ID_Fund,
                Period = fundReportRequest.Period,
            };
            return await _reportRepository.GenerateFundReportAsync(fundReport);
        }

        public async Task<GroupReport> GenerateGroupReportAsync(GroupReportRequest groupReportRequest)
        {
            GroupReport groupReport = new GroupReport
            {
                ID_GroupReport = groupReportRequest.ID_Group,
                Period = groupReportRequest.Period,
            };
            return await _reportRepository.GenerateGroupReportAsync(groupReport);
        }

        public async Task<FundReport?> GetFundReportAsync(Guid ID_FundReport)
        {
            return await _reportRepository.GetFundReportAsync(ID_FundReport);
        }

        public async Task<GroupReport?> GetGroupReportAsync(Guid ID_GroupReport)
        {
            return await _reportRepository.GetGroupReportAsync(ID_GroupReport);
        }

        public async Task<List<FundReport>> ListFundReportsAsync()
        {
            return await _reportRepository.ListFundReportsAsync();
        }

        public async Task<List<GroupReport>> ListGroupReportsAsync()
        {
            return await _reportRepository.ListGroupReportsAsync();
        }
    }
}
