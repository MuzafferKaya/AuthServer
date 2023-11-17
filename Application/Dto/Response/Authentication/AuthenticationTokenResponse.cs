namespace Dto.Response.Authentication
{
    public class AuthenticationTokenResponse
    {
        public string accesToken { get; set; }
        public DateTime accesTokenExpiration { get; set; }
    }
}
