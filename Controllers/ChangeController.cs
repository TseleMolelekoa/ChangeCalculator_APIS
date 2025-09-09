using Microsoft.AspNetCore.Mvc;
using ChangeCalculator.Models;
using ChangeCalculator.Services;

namespace ChangeCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChangeController : ControllerBase
    {
        private readonly IChangeCalculatorService _changeCalculatorService;
        private readonly ILogger<ChangeController> _logger;

        public ChangeController(IChangeCalculatorService changeCalculatorService, ILogger<ChangeController> logger)
        {
            _changeCalculatorService = changeCalculatorService;
            _logger = logger;
        }

   
        /// Calculates the minimum number of South African banknotes and coins for a given amount.
        
        /// <param name="request">The amount to calculate change for.</param>
        /// <returns>A breakdown of notes and coins required.</returns>
        /// <response code="200">Returns the change breakdown.</response>
        /// <response code="400">If the request is invalid.</response>
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ChangeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<ChangeResponse> CalculateChange([FromBody] ChangeRequest request)
        {
            try
            {
                _logger.LogInformation("Calculating change for amount: {Amount}", request.Amount);

                var result = _changeCalculatorService.CalculateChange(request.Amount);

                _logger.LogInformation("Change calculation completed successfully for amount: {Amount}", request.Amount);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating change for amount: {Amount}", request.Amount);

                // Return structured error response
                return BadRequest(new ErrorResponse
                {
                    Message = "An error occurred while calculating change",
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
