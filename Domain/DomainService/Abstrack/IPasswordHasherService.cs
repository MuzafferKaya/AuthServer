namespace DomainService.Abstrack
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
