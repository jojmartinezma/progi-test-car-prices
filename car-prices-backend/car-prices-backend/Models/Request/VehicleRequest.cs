namespace car_prices_backend.Models.Request
{
    public enum vehicleTypeEnum
    {
        Common,
        Luxury
    }
    public class VehicleRequest
    {
        public string VehicleBasePrice { get; set; }
        public vehicleTypeEnum VehicleType { get; set; }
    }
}
