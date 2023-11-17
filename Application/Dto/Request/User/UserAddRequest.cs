namespace Dto.Request.User
{
    public class UserAddRequest
    {
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? passwordHash { get; set; }
    }
}
