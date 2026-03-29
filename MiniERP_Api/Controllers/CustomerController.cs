using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;
using MiniERP_Infrastructure;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly AppDbContext _context;
        public CustomerController(ICustomerService customerService, AppDbContext context)
        {
            _customerService = customerService;
            _context = context;
        }

        [HttpPost("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
            => Ok(await _context.Customers.ToListAsync());


        // Mode 1=Insert, 3=Update, 4=Delete
        [HttpPost("ManageCustomer")]
        public async Task<IActionResult> ManageCustomer(CustomerRequestDto dto)
        {
            var result = await _customerService.ManageCustomerAsync(dto.Mode, dto.Id, dto.Name, dto.Phone, dto.Address);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
