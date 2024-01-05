using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Roles")]
    public class Role : EntityBase
    {
        public string RoleName { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
