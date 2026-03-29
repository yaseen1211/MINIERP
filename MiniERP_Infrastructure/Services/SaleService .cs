using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services;
using System.Text.Json;

namespace MiniERP_Infrastructure.Services
{
    public class SaleService : ISaleService
    {
        private readonly AppDbContext _context;
        public SaleService(AppDbContext context) => _context = context;

        public async Task<SpResponseDto> CreateSaleAsync(CreateSaleDto dto)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(dto.Items);

                var result = await _context.SpResponse
                    .FromSqlRaw("EXEC InsertSale @CustomerId, @CreatedBy, @Items",
                        new SqlParameter("@CustomerId", dto.CustomerId),
                        new SqlParameter("@CreatedBy", dto.CreatedBy),
                        new SqlParameter("@Items", jsonData))
                    .ToListAsync();

                return result.FirstOrDefault() ?? new SpResponseDto { Success = true, Message = "Sale created successfully" };
            }
            catch (Exception ex)
            {
                return new SpResponseDto { Success = false, Message = ex.Message };
            }
        }
    }
}
