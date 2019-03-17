using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Data.Model
{
    public class Image
    {
        [Key] 
        public long Id { get; set; }

        public byte[] Data { get; set; }

        public Flat Flat { get; set; }
    }
}