using Microsoft.AspNetCore.Mvc;
using MVProject.Application.Interfaces;
using MVProject.Application.DTOs.Report;

namespace MVProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("generate-fund-report")]
        public async Task<IActionResult> GenerateFundReport([FromBody] FundReportRequest request)
        {
            var result = await _reportService.GenerateFundReportAsync(request);
            if (result == null)
            {
                return BadRequest("Виникла помилка при формуванні звіту");
            }
            return Ok(result);
        }

        [HttpPost("generate-group-report")]
        public async Task<IActionResult> GenerateGroupReport([FromBody] GroupReportRequest request)
        {
            var result = await _reportService.GenerateGroupReportAsync(request);
            if (result == null)
            {
                return BadRequest("Виникла помилка при формуванні звіту");
            }
            return Ok(result);
        }

        [HttpGet("fund-report/{id}")]
        public async Task<IActionResult> GetFundReportById(Guid id)
        {
            var result = await _reportService.GetFundReportAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("group-report/{id}")]
        public async Task<IActionResult> GetGroupReportById(Guid id)
        {
            var result = await _reportService.GetGroupReportAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            var fundReport = await _reportService.GetFundReportAsync(id);
            if (fundReport != null)
            {
                return Ok(new ReportByIdResponse
                {
                    ReportType = "fund",
                    Data = fundReport
                });
            }

            var groupReport = await _reportService.GetGroupReportAsync(id);
            if (groupReport != null)
            {
                return Ok(new ReportByIdResponse
                {
                    ReportType = "group",
                    Data = groupReport
                });
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ListReports()
        {
            var fundReports = await _reportService.ListFundReportsAsync();
            var groupReports = await _reportService.ListGroupReportsAsync();

            var response = new ReportsResponse
            {
                FundReports = fundReports,
                GroupReports = groupReports
            };

            return Ok(response);
        }
    }
}
