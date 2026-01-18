using FurnitureStoreAPI.Models.T3ChatObserver;
using FurnitureStoreAPI.Services.ObserverStockService;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObserverStockController : ControllerBase
    {
        private readonly ObserverStockService
           _stockService;

        public ObserverStockController(
            ObserverStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("stock/create")]
        public IActionResult CreateStock(
            [FromBody] CreateStockRequest request)
        {
            try
            {
                _stockService.CreateStock(
                    request.Symbol,
                    request.CompanyName,
                    request.InitialPrice);

                var stock = _stockService
                    .GetStock(request.Symbol);

                return CreatedAtAction(
                    nameof(GetStock),
                    new { symbol = request.Symbol },
                    stock);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { error = ex.Message });
            }
        }

        [HttpPost("observer/attach")]
        public IActionResult AttachObserver(
            [FromBody] AttachObserverRequest request)
        {
            try
            {
                var result = _stockService
                    .AttachObserver(request);

                return Ok(new
                {
                    message =
                        $"Observer attached successfully",
                    stock = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { error = ex.Message });
            }
        }

        [HttpDelete("observer/detach")]
        public IActionResult DetachObserver(
            [FromQuery] string stockSymbol,
            [FromQuery] string observerName)
        {
            try
            {
                var result = _stockService
                    .DetachObserver(
                        stockSymbol,
                        observerName);

                return Ok(new
                {
                    message =
                        $"Observer detached successfully",
                    stock = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { error = ex.Message });
            }
        }

        [HttpPost("price/update")]
        public IActionResult UpdateStockPrice(
            [FromBody] UpdateStockPriceRequest request)
        {
            try
            {
                var result = _stockService
                    .UpdateStockPrice(
                        request.StockSymbol,
                        request.NewPrice);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { error = ex.Message });
            }
        }

        [HttpGet("stock/{symbol}")]
        public IActionResult GetStock(string symbol)
        {
            try
            {
                var stock = _stockService
                    .GetStock(symbol);

                return Ok(stock);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(
                    new { error = ex.Message });
            }
        }

        [HttpGet("stocks")]
        public IActionResult GetAllStocks()
        {
            var stocks = _stockService.GetAllStocks();
            return Ok(new
            {
                totalStocks = stocks.Count,
                stocks
            });
        }
    }
    public class CreateStockRequest
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal InitialPrice { get; set; }
    }
}
