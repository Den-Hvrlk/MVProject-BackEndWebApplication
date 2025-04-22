using MVProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVProject.Application.DTOs.Report;

namespace MVProject.Application.Interfaces
{
    public interface IReportService
    {
        Task<FundReport> GenerateFundReportAsync(FundReportRequest fundReportRequest);
        Task<GroupReport> GenerateGroupReportAsync(GroupReportRequest groupReportRequest);
        Task<FundReport?> GetFundReportAsync(Guid ID_FundReport);
        Task<GroupReport?> GetGroupReportAsync(Guid ID_GroupReport);
        Task<List<FundReport>> ListFundReportsAsync();
        Task<List<GroupReport>> ListGroupReportsAsync();
    }
}
