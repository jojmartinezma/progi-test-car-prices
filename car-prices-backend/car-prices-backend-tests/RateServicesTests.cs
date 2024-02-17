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

        //[Fact]
        //public async Task CalculateRates_ShouldReturnCorrectResponse()
        //{
        //    // Arrange
        //    var request = new VehicleRequest
        //    {
        //        VehicleBasePrice = 1000,
        //        VehicleType = vehicleTypeEnum.Common // or Luxury for different scenarios
        //                                             // Add other properties as needed
        //    };

        //    var ratesService = new RatesService();

        //    // Act
        //    var result = await ratesService.CalculateRates(request);

        //    // Assert
        //    Assert.NotNull(result);
        //    // Add more assertions based on the expected values
        //    Assert.Equal(expectedBasicFee, result.Basic);
        //    Assert.Equal(expectedSpecialFee, result.Special);
        //    Assert.Equal(expectedAssociationPrice, result.Asosiation);
        //    Assert.Equal(expectedTotal, result.Total);
        //}
    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.