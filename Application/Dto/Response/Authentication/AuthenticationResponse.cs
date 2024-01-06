namespace Dto.Response.Authentication
{
    public class AuthenticationResponse
    {
        public string accesToken { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
    }
}
