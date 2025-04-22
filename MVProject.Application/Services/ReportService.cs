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

        public async Task<List<FundReportDto>> ListFundReportsAsync()
        {
            var raw = await _reportRepository.ListFundReportsAsync();
            var result = raw.Cast<dynamic>();

            return result.Select(x => new FundReportDto
            {
                ID_FundReport = x.Report.ID_FundReport,
                FundName = x.FundName,
                Period = x.Report.Period,
                CompletedRequestsCount = x.Report.CompletedRequestsCount,
                CompletedFundraisingCount = x.Report.CompletedFundraisingCount,
                TotalGoals = x.Report.TotalGoals,
                TotalRaised = x.Report.TotalRaised
            }).ToList();
        }

        public async Task<List<GroupReportDto>> ListGroupReportsAsync()
        {
            var raw = await _reportRepository.ListGroupReportsAsync();
            var result = raw.Cast<dynamic>();

            return result.Select(x => new GroupReportDto
            {
                ID_GroupReport = x.Report.ID_GroupReport,
                GroupName = x.GroupName,
                Period = x.Report.Period,
                FundraisingCount = x.Report.FundraisingCount,
                ClosedFundraisingCount = x.Report.ClosedFundraisingCount,
                GoalToBeRecieved = x.Report.GoalToBeRecieved,
                FundsReceived = x.Report.FundsReceived,
                AllRequestCount = x.Report.AllRequestCount,
                CompletedRequestCount = x.Report.CompletedRequestCount,
                IncompleteRequestCount = x.Report.IncompleteRequestCount
            }).ToList();
        }
    }
}
