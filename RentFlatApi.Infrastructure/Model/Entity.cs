using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Infrastructure.Model
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}