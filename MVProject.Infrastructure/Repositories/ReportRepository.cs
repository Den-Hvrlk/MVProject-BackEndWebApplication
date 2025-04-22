using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVProject.Domain.Interfaces;
using MVProject.Domain.Entities;
using MVProject.Domain.Entities.Views;
using MVProject.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace MVProject.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;
        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<FundReport> GenerateFundReportAsync(FundReport fundReport)
        {
            var existingReport = await _context.FundReports
                .FirstOrDefaultAsync(r => r.Period == fundReport.Period && r.ID_Fund == fundReport.ID_Fund);

            if (existingReport != null)
                return existingReport;

            var periodStart = DateOnly.FromDateTime(new DateTime(fundReport.Period.Year, fundReport.Period.Month, 1));
            var periodEnd = periodStart.AddMonths(1).AddDays(-1);

            var completedRequestsData = await _context.ReportForCompletedRequestsByFunds
                .Where(r => r.ID_Fund == fundReport.ID_Fund &&
                            r.RequestCreateDate >= periodStart &&
                            r.RequestCreateDate <= periodEnd)
                .GroupBy(r => r.ID_Fund)
                .Select(g => new
                {
                    CompletedRequestCount = g.Sum(x => x.CompletedRequestCount ?? 0)
                })
                .FirstOrDefaultAsync();

            var recievedFundsData = await _context.ReportForFundRecievedFunds
                .Where(r => r.ID_Fund == fundReport.ID_Fund &&
                            r.FundrCreateDate >= periodStart &&
                            r.FundrCreateDate <= periodEnd)
                .GroupBy(r => r.ID_Fund)
                .Select(g => new
                {
                    CompletedFundraisingCount = g.Sum(x => x.CompletedFundraisingCount ?? 0),
                    TotalGoals = g.Sum(x => x.TotalGoals),
                    TotalRaised = g.Sum(x => x.TotalRaised)
                })
                .FirstOrDefaultAsync();

            var newReport = new FundReport
            {
                ID_FundReport = Guid.NewGuid(),
                CompletedRequestsCount = completedRequestsData?.CompletedRequestCount ?? 0,
                CompletedFundraisingCount = recievedFundsData?.CompletedFundraisingCount ?? 0,
                TotalGoals = recievedFundsData?.TotalGoals ?? 0,
                TotalRaised = recievedFundsData?.TotalRaised ?? 0,
                Period = fundReport.Period,
                ID_Fund = fundReport.ID_Fund
            };

            await _context.FundReports.AddAsync(newReport);
            await _context.SaveChangesAsync();

            return newReport;
        }

        public async Task<GroupReport> GenerateGroupReportAsync(GroupReport groupReport)
        {
            var existingReport = await _context.GroupReports
                .FirstOrDefaultAsync(r => r.Period == groupReport.Period && r.ID_Group == groupReport.ID_Group);

            if (existingReport != null)
                return existingReport;

            var periodStart = DateOnly.FromDateTime(new DateTime(groupReport.Period.Year, groupReport.Period.Month, 1));
            var periodEnd = periodStart.AddMonths(1).AddDays(-1);

            var recievedFundsData = await _context.ReportForGroupRecievedFunds
                .Where(r => r.ID_Group == groupReport.ID_Group &&
                            r.FundrCreateDate >= periodStart &&
                            r.FundrCreateDate <= periodEnd)
                .GroupBy(r => r.ID_Group)
                .Select(g => new
                {
                    FundraisingCount = g.Sum(x => x.FundraisingCount),
                    ClosedFundraisingCount = g.Sum(x => x.ClosedFundraisingCount),
                    GoalToBeRecieved = g.Sum(x => x.GoalToBeRecieved),
                    FundsReceived = g.Sum(x => x.FundsReceived)
                })
                .FirstOrDefaultAsync();

            var requestData = await _context.ReportForGroupRequests
                .Where(r => r.ID_Group == groupReport.ID_Group &&
                            r.RequestCreateDate >= periodStart &&
                            r.RequestCreateDate <= periodEnd)
                .GroupBy(r => r.ID_Group)
                .Select(g => new
                {
                    AllRequestCount = g.Sum(x => x.AllRequestCount),
                    CompletedRequestCount = g.Sum(x => x.CompletedRequestCount),
                    IncompleteRequestCount = g.Sum(x => x.IncompleteRequestCount)
                })
                .FirstOrDefaultAsync();

            var newReport = new GroupReport
            {
                ID_GroupReport = Guid.NewGuid(),
                Period = groupReport.Period,
                ID_Group = groupReport.ID_Group,
                FundraisingCount = recievedFundsData?.FundraisingCount ?? 0,
                ClosedFundraisingCount = recievedFundsData?.ClosedFundraisingCount ?? 0,
                GoalToBeRecieved = recievedFundsData?.GoalToBeRecieved ?? 0,
                FundsReceived = recievedFundsData?.FundsReceived ?? 0,
                AllRequestCount = requestData?.AllRequestCount ?? 0,
                CompletedRequestCount = requestData?.CompletedRequestCount ?? 0,
                IncompleteRequestCount = requestData?.IncompleteRequestCount ?? 0
            };

            await _context.GroupReports.AddAsync(newReport);
            await _context.SaveChangesAsync();

            return newReport;
        }
        public async Task<FundReport?> GetFundReportAsync(Guid ID_FundReport)
        {
            return await _context.FundReports.FirstOrDefaultAsync(r => r.ID_FundReport == ID_FundReport);
        }
        public async Task<GroupReport?> GetGroupReportAsync(Guid ID_GroupReport)
        {
            return await _context.GroupReports.FirstOrDefaultAsync(r => r.ID_GroupReport == ID_GroupReport);
        }
        public async Task<List<FundReport>> ListFundReportsAsync()
        {
            return await _context.FundReports.OrderByDescending(r => r.Period).ToListAsync();
        }
        public async Task<List<GroupReport>> ListGroupReportsAsync()
        {
            return await _context.GroupReports.OrderByDescending(r => r.Period).ToListAsync();
        }
    }
}
