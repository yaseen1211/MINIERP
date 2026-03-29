using Microsoft.AspNetCore.Mvc;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService) => _reportService = reportService;

        // Mode 1=TotalSalesToday, 2=Revenue, 3=TopProducts,
        // 4=TopCustomers, 5=LowStock, 6=StockSummary, 7=MonthlySales
        [HttpPost("ManageReport")]
        public async Task<IActionResult> ManageReport(ReportRequestDto dto)
        {
            var result = await _reportService.ManageReportAsync(dto.Mode, dto.FromDate, dto.ToDate);
            return Ok(result);
        }
    }
}
