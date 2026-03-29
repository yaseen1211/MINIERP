using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniERP.Models;
using MiniERP_Application.DTOs;
using MiniERP_Application.Services.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto request)
        {
    
            var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var accessToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            _context.RefreshTokens.Add(new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            });

            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto request)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = request.RoleId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == refreshToken && !x.IsRevoked);

            if (token == null || token.ExpiryDate < DateTime.UtcNow)
                throw new Exception("Invalid refresh token");

            token.IsRevoked = true;

            var newAccessToken = GenerateJwtToken(token.User);
            var newRefreshToken = GenerateRefreshToken();

            _context.RefreshTokens.Add(new RefreshToken
            {
                UserId = token.UserId,
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            });

            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        // 🔐 JWT TOKEN
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

           var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("UserId", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name)
           };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // 🔁 REFRESH TOKEN
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
