using System;
using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Infrastructure.Model
{
    public abstract class Entity
    {
        [Key] 
        public long Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfUpdate { get; set; }
    }
}