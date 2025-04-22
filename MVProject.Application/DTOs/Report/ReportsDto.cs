using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.Report
{
    public class FundReportDto
    {
        public Guid ID_FundReport { get; set; }
        public string FundName { get; set; } = string.Empty;
        public DateOnly Period { get; set; }
        public int CompletedRequestsCount { get; set; }
        public int CompletedFundraisingCount { get; set; }
        public decimal TotalGoals { get; set; }
        public decimal TotalRaised { get; set; }
    }

    public class GroupReportDto
    {
        public Guid ID_GroupReport { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public DateOnly Period { get; set; }
        public int FundraisingCount { get; set; }
        public int ClosedFundraisingCount { get; set; }
        public decimal GoalToBeRecieved { get; set; }
        public decimal FundsReceived { get; set; }
        public int AllRequestCount { get; set; }
        public int? CompletedRequestCount { get; set; }
        public int? IncompleteRequestCount { get; set; }
    }
}
