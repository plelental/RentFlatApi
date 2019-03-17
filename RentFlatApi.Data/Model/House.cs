namespace RentFlatApi.Data.Model
{
    public class House : RealEstate
    {
        public int FieldMeters { get; set; }
        public int NumberOfFloors { get; set; }
    }
}