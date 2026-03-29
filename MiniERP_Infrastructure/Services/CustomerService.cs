using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;

namespace MiniERP_Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context) => _context = context;

        public async Task<SpResponseDto> ManageCustomerAsync(int mode, int? id = null, string name = null, string phone = null, string address = null)
        {
            try
            {
                var result = await _context.SpResponse
                    .FromSqlRaw("EXEC ManageCustomer @Name, @Phone, @Address, @CustomerId, @Mode",
                        new SqlParameter("@Name", (object?)name ?? DBNull.Value),
                        new SqlParameter("@Phone", (object?)phone ?? DBNull.Value),
                        new SqlParameter("@Address", (object?)address ?? DBNull.Value),
                        new SqlParameter("@CustomerId", (object?)id ?? DBNull.Value),
                        new SqlParameter("@Mode", mode))
                    .ToListAsync();

                return result.FirstOrDefault()
                    ?? new SpResponseDto { Success = true, Message = "Done" };
            }
            catch (Exception ex)
            {
                return new SpResponseDto { Success = false, Message = ex.Message };
            }
        }
    }
}
