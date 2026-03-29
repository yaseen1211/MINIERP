using Microsoft.AspNetCore.Mvc;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services.Auth;

namespace MiniERP_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // 🔐 REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        // 🔐 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }

        // 🔁 REFRESH TOKEN
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string refreshToken)
        {
            var result = await _authService.RefreshTokenAsync(refreshToken);
            return Ok(result);
        }
    }
}
