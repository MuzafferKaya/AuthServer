using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
