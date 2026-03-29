namespace MiniERP_Application.DTOs
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }

    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
