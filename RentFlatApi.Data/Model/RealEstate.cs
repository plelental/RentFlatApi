using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Data.Model
{
    public class RealEstate
    {
        [Key]
        public long Id { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int NumberOfRooms { get; set; }
        public int SquareMeters { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}