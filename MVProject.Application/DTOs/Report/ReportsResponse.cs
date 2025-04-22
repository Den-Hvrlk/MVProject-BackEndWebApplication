using MVProject.Domain.Entities;

namespace MVProject.Application.DTOs.Report
{
    public class ReportsResponse
    {
        public List<FundReport> FundReports { get; set; } = new();
        public List<GroupReport> GroupReports { get; set; } = new();
    }
}
