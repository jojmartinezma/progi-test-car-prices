using car_prices_backend.Models.Request;
using car_prices_backend.Models.Responses;
using car_prices_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_prices_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesCalculationController : ControllerBase
    {
        private readonly IRatesService _rateService;

        public RatesCalculationController(IRatesService rateService)
        {
            _rateService = rateService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateRates([FromBody] VehicleRequest request)
        {
            return Ok(await _rateService.CalculateRates(request));
        }
    }
}
