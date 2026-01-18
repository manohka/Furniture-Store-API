using FurnitureStoreAPI.Models.T3ChatStrategy;
using FurnitureStoreAPI.Services.StrategyPaymentService;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StrategyPaymentController : ControllerBase
    {
        private readonly StrategyPaymentService
            _paymentService;

        public StrategyPaymentController(
            StrategyPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("methods")]
        public IActionResult GetPaymentMethods()
        {
            var methods = _paymentService
                .GetAvailablePaymentMethods();

            return Ok(new
            {
                availableMethods = methods.Count,
                methods
            });
        }

        [HttpPost("validate")]
        public IActionResult ValidatePayment(
            [FromBody] ValidatePaymentRequest request)
        {
            try
            {
                var result = _paymentService
                    .ValidatePayment(
                        request.PaymentMethod,
                        request.PaymentDetails);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPost("process")]
        public IActionResult ProcessPayment(
            [FromBody] ProcessPaymentRequest request)
        {
            try
            {
                if (request.Amount <= 0)
                {
                    return BadRequest(
                        "Amount must be greater than 0");
                }

                if (string.IsNullOrEmpty(
                    request.PaymentMethod))
                {
                    return BadRequest(
                        "Payment method is required");
                }

                var result = _paymentService
                    .ProcessPayment(request);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet("transactions")]
        public IActionResult GetAllTransactions()
        {
            var transactions = _paymentService
                .GetAllTransactions();

            return Ok(new
            {
                totalTransactions =
                    transactions.Count,
                totalRevenue = transactions
                    .Sum(t => t.TotalAmount),
                transactions
            });
        }

        [HttpGet("transaction/{transactionId}")]
        public IActionResult GetTransaction(
            string transactionId)
        {
            try
            {
                var transaction = _paymentService
                    .GetTransaction(transactionId);

                return Ok(transaction);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    error = ex.Message
                });
            }
        }
    }
}
