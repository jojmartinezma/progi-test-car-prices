namespace car_prices_backend.Models.Responses
{
    public class VehicleResponse
    {
        public float Basic { get; set; }
        public float Special { get; set; }
        public float Asosiation { get; set; }
        public float Storage { get; } = 100;
        public double Total { get; set; }
    }
}
