using MiniERP_Application.DTOs;

namespace MiniERP_Application.Services
{
    public interface ICustomerService
    {
        Task<SpResponseDto> ManageCustomerAsync(int mode, int? id = null, string name = null, string phone = null, string address = null);
    }
}
