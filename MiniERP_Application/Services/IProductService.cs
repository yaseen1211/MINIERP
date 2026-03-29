using MiniERP_Application.DTOs;

namespace MiniERP_Application.Services
{
    public interface IProductService
    {
        Task<SpResponseDto> ManageProductAsync(int mode, int? id = null, string productName = null, int stockQty = 0, decimal price = 0);
    }
}
