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
            VehicleResponse response = new VehicleResponse();

            // validate vehicle fee
            response.Basic = CalculateBasicFee(request);
            response.Special = CalculateSpecialFee(request);
            response.Asosiation = CalculateAssociationPrice(request);
            response.Total = Math.Round(request.VehicleBasePrice + response.Basic + response.Special + response.Asosiation + response.Storage, 2);
            return response;
        }

        // method to calculate -	Basic user fee: 10% of the price of the vehicle
        private float CalculateBasicFee(VehicleRequest request)
        {
            // by default we assume that the type is common
            float fee = (float)(request.VehicleBasePrice * 0.1);
            if (request.VehicleType == vehicleTypeEnum.Luxury)
            {
                if (fee < 25)
                {
                    fee = 25;
                }
                if (fee > 200)
                {
                    fee = 200;
                }
            }
            else
            {
                if (fee < 10)
                {
                    fee = 10;
                }
                if (fee > 50)
                {
                    fee = 50;
                }
            }

            return fee;
        }

        // method to calculate -	The seller's special fee
        private float CalculateSpecialFee(VehicleRequest request)
        {
            if(request.VehicleType == vehicleTypeEnum.Luxury)
            {
                return (float)(request.VehicleBasePrice * 0.04);
            }

            // default vehicle type common
            return (float)(request.VehicleBasePrice * 0.02);
        }

        // method to calculate -	The added costs for the association based on the price of the vehicle
        private float CalculateAssociationPrice(VehicleRequest request)
        {
            if (request.VehicleBasePrice <= 500)
            {
                return 5;
            }
            else if (request.VehicleBasePrice > 500 && request.VehicleBasePrice <= 1000)
            {
                return 10;
            }
            else if (request.VehicleBasePrice > 1000 && request.VehicleBasePrice <= 3000)
            {
                return 15;
            }
            else
            {
                return 20;
            }
        }
    }
}
