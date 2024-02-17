using car_prices_backend.Models.Request;
using car_prices_backend.Models.Responses;

namespace car_prices_backend.Services
{
    public interface IRatesService
    {
        Task<VehicleResponse> CalculateRates(VehicleRequest request);
    }

    public class RatesService : IRatesService
    {

        public async Task<VehicleResponse> CalculateRates(VehicleRequest request)
        {
            await Task.Delay(1);
            return new VehicleResponse();
        }
    }
}
