using MiniERP_Application.DTOs;

namespace MiniERP_Application.Services
{
    public interface ISaleService
    {
        Task<SpResponseDto> CreateSaleAsync(CreateSaleDto dto);
    }
}
