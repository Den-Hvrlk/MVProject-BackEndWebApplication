using MVProject.Domain.Entities;

namespace MVProject.Application.DTOs.Report
{
    public class ReportsResponse
    {
        public List<FundReportDto> FundReports { get; set; } = new();
        public List<GroupReportDto> GroupReports { get; set; } = new();
    }
}
