using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;
using MiniERP_Infrastructure;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly AppDbContext _context;
        public RoleController(IRoleService roleService, AppDbContext context)
        {
            _roleService = roleService;
            _context = context;
        }

        [HttpPost("GetRole")]
        public async Task<IActionResult> GetRole()
            => Ok(await _context.Roles.ToListAsync());

        // Mode 1=Insert, 3=Update, 4=Delete
        [HttpPost("ManageRole")]
        public async Task<IActionResult> ManageRole(RoleRequestDto dto)
        {
            var result = await _roleService.ManageRoleAsync(dto.Mode, dto.Id, dto.Name);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
