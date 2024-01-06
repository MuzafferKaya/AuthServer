using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
