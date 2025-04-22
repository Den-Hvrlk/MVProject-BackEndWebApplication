using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.Report
{
    public class GroupReportRequest
    {
        public Guid ID_Group { get; set; }
        public DateOnly Period { get; set; }
    }
}
