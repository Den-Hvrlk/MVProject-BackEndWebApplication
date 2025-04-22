using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.Report
{
    public class FundReportRequest
    {
        public Guid ID_Fund { get; set; }
        public DateOnly Period { get; set; }
    }
}
