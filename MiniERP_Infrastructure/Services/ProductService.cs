using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;

namespace MiniERP_Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) => _context = context;

        public async Task<SpResponseDto> ManageProductAsync(int mode, int? id = null, string productName = null, int stockQty = 0, decimal price = 0)
        {
            try
            {
                var result = await _context.SpResponse
                    .FromSqlRaw("EXEC ManageProduct @Mode, @Id, @ProductName, @StockQty, @Price",
                        new SqlParameter("@Mode", mode),
                        new SqlParameter("@Id", (object?)id ?? DBNull.Value),
                        new SqlParameter("@ProductName", (object?)productName ?? DBNull.Value),
                        new SqlParameter("@StockQty", stockQty),
                        new SqlParameter("@Price", price))
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
