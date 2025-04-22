using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.Report
{
    public class ReportByIdResponse
    {
        public string ReportType { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
