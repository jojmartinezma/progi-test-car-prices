using car_prices_backend.Models.Request;
using car_prices_backend.Services;
using NSubstitute;
using System.Reflection;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace car_prices_backend_tests
{
    public class RateServicesTests
    {
        // methdo to get private methods using reflection
        private T InvokePrivateMethod<T>(object instance, string methodName, params object[] parameters)
        {
            var methodInfo = instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)methodInfo.Invoke(instance, parameters);
        }

        [Theory]
        [InlineData(1000, 10)]
        [InlineData(398, 5.00)]
        [InlineData(501, 10.00)]
        [InlineData(57, 5.00)]
        [InlineData(1800.00, 15.00)]
        [InlineData(1100, 15.00)]
        [InlineData(1000000.00, 20.00)]
        public void CalculateAssociationPrice_andReturnCorrectValue(float vehicleBasePrice, float expected)
        {
            // Arrange
            var ratesService = new RatesService();
            var request = new VehicleRequest { VehicleBasePrice = vehicleBasePrice };

            // Act
            var result = InvokePrivateMethod<float>(ratesService, "CalculateAssociationPrice", request);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, vehicleTypeEnum.Common, 20)]
        [InlineData(398, vehicleTypeEnum.Common, 7.96)]
        [InlineData(501, vehicleTypeEnum.Common, 10.02)]
        [InlineData(57, vehicleTypeEnum.Common, 1.14)]
        [InlineData(1800.00, vehicleTypeEnum.Luxury, 72.00)]
        [InlineData(1100, vehicleTypeEnum.Common, 22.00)]
        [InlineData(1000000.00, vehicleTypeEnum.Luxury, 40000.00)]
        public void CalculateSpecialFee_andReturnCorrectValue(float vehicleBasePrice, vehicleTypeEnum vehicleTypeEnum, float expected)
        {
            // Arrange
            var ratesService = new RatesService();
            var request = new VehicleRequest { 
                VehicleBasePrice = vehicleBasePrice,
                VehicleType = vehicleTypeEnum
            };

            // Act
            var result = InvokePrivateMethod<float>(ratesService, "CalculateSpecialFee", request);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, vehicleTypeEnum.Common, 50)]
        [InlineData(398, vehicleTypeEnum.Common, 39.80)]
        [InlineData(501, vehicleTypeEnum.Common, 50.00)]
        [InlineData(57, vehicleTypeEnum.Common, 10)]
        [InlineData(1800.00, vehicleTypeEnum.Luxury, 180)]
        [InlineData(1100, vehicleTypeEnum.Common, 50)]
        [InlineData(1000000.00, vehicleTypeEnum.Luxury, 200.00)]
        public void CalculateCalculateBasicFee_andReturnCorrectValue(float vehicleBasePrice, vehicleTypeEnum vehicleTypeEnum, float expected)
        {
            // Arrange
            var ratesService = new RatesService();
            var request = new VehicleRequest
            {
                VehicleBasePrice = vehicleBasePrice,
                VehicleType = vehicleTypeEnum
            };

            // Act
            var result = InvokePrivateMethod<float>(ratesService, "CalculateBasicFee", request);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, vehicleTypeEnum.Common, 1180)]
        [InlineData(398, vehicleTypeEnum.Common, 550.76)]
        [InlineData(501, vehicleTypeEnum.Common, 671.02)]
        [InlineData(57, vehicleTypeEnum.Common, 173.14)]
        [InlineData(1800.00, vehicleTypeEnum.Luxury, 2167.00)]
        [InlineData(1100, vehicleTypeEnum.Common, 1287.00)]
        [InlineData(1000000.00, vehicleTypeEnum.Luxury, 1040320.00)]
        public async Task CalculateRates_ShouldReturnCorrectResponse(float vehicleBasePrice, vehicleTypeEnum vehicleTypeEnum, double expected)
        {
            // Arrange
            var request = new VehicleRequest
            {
                VehicleBasePrice = vehicleBasePrice,
                VehicleType = vehicleTypeEnum
            };

            var ratesService = new RatesService();

            // Act
            var result = await ratesService.CalculateRates(request);

            // Assert
            Assert.NotNull(result);

            // validations of total $
            Assert.Equal(expected, result.Total);
        }
    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.