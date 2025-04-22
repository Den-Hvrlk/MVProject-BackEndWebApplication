using MVProject.Application.DTOs.Report;
using MVProject.Application.Interfaces;
using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces;
using System.Dynamic;

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
            var result = raw.Cast<ExpandoObject>();

            return result.Select(x =>
            {
                dynamic d = x;

                return new FundReportDto
                {
                    ID_FundReport = d.Report.ID_FundReport,
                    FundName = d.FundName,
                    Period = d.Report.Period,
                    CompletedRequestsCount = d.Report.CompletedRequestsCount,
                    CompletedFundraisingCount = d.Report.CompletedFundraisingCount,
                    TotalGoals = d.Report.TotalGoals,
                    TotalRaised = d.Report.TotalRaised
                };
            }).ToList();
        }

        public async Task<List<GroupReportDto>> ListGroupReportsAsync()
        {
            var raw = await _reportRepository.ListGroupReportsAsync();
            var result = raw.Cast<ExpandoObject>();

            return result.Select(x =>
            {
                dynamic d = x;

                return new GroupReportDto
                {
                    ID_GroupReport = d.Report.ID_GroupReport,
                    GroupName = d.Group,
                    Period = d.Report.Period,
                    FundraisingCount = d.Report.FundraisingCount,
                    ClosedFundraisingCount = d.Report.ClosedFundraisingCount,
                    GoalToBeRecieved = d.Report.GoalToBeRecieved,
                    FundsReceived = d.Report.FundsReceived,
                    AllRequestCount = d.Report.AllRequestCount,
                    CompletedRequestCount = d.Report.CompletedRequestCount,
                    IncompleteRequestCount = d.Report.IncompleteRequestCount
                };
            }).ToList();
        }
    }
}
