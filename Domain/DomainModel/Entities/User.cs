using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("users")]
    public class User : EntityBase
    {
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
    }
}
