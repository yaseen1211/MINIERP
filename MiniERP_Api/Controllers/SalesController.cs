using Microsoft.AspNetCore.Mvc;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleDto dto)
        {
            var result = await _saleService.CreateSaleAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
