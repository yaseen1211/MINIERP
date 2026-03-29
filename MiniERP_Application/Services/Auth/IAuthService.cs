using MiniERP_Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto request);
        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
        Task<bool> RegisterAsync(RegisterDto request);
    }
}
