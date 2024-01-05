namespace DomainService.Abstrack
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
