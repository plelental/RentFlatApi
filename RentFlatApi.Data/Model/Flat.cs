namespace RentFlatApi.Data.Model
{
    public  class Flat : RealEstate
    {
        public int Floor { get; set; }
        public bool IsElevator { get; set; }
    }
}