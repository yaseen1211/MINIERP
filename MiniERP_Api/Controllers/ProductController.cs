using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;
using MiniERP_Infrastructure;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _context;
        public ProductController(IProductService productService, AppDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpPost("GetProduct")]
        public async Task<IActionResult> GetProduct()
            => Ok(await _context.Products.Where(p => p.IsActive).ToListAsync());



        // Mode 1=Insert, 3=Update, 4=SoftDelete
        [HttpPost("ManageProduct")]
        public async Task<IActionResult> ManageProduct(ProductRequestDto dto)
        {
            var result = await _productService.ManageProductAsync(dto.Mode, dto.Id, dto.ProductName, dto.StockQty, dto.Price);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
