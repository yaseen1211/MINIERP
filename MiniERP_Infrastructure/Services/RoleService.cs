using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;

namespace MiniERP_Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context) => _context = context;

        public async Task<SpResponseDto> ManageRoleAsync(int mode, int? id = null, string name = null)
        {
            try
            {
                var result = await _context.SpResponse
                    .FromSqlRaw("EXEC ManageRole @Mode, @Id, @Name",
                        new SqlParameter("@Mode", mode),
                        new SqlParameter("@Id", (object?)id ?? DBNull.Value),
                        new SqlParameter("@Name", (object?)name ?? DBNull.Value))
                    .ToListAsync();

                return result.FirstOrDefault() ?? new SpResponseDto { Success = true, Message = "Operation completed successfully" };
            }
            catch (Exception ex)
            {
                return new SpResponseDto { Success = false, Message = ex.Message };
            }
        }
    }
}
