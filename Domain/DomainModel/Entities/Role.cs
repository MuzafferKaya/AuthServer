using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        public string RoleName { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
