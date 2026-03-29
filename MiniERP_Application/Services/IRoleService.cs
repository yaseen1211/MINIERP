using MiniERP_Application.DTOs;

namespace MiniERP_Application.Services
{
    public interface IRoleService
    {
        Task<SpResponseDto> ManageRoleAsync(int mode, int? id = null, string name = null);
    }
}
