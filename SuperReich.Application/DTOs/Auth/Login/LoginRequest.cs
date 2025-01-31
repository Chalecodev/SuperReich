namespace SuperReich.Application.DTOs.Auth.Login
{
    public class LoginRequest
    {
        public string Rut { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
