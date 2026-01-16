using FurnitureStoreAPI.Models.SimpleFlyWeight.cs;
using FurnitureStoreAPI.Services.SimpleFlyWeightService;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleFlyweightController : ControllerBase
    {
        private readonly SimpleFlyweightService
            _service;

        public SimpleFlyweightController(
            SimpleFlyweightService service)
        {
            _service = service;
        }

        [HttpPost("create-shapes")]
        public IActionResult CreateShapes(
            [FromBody] CreateShapesRequest request)
        {
            try
            {
                if (request.Count <= 0)
                {
                    return BadRequest(
                        "Count must be greater than 0");
                }

                _service.CreateShapes(
                    request.Count,
                    request.ColorName,
                    request.HexCode);

                return Ok(new
                {
                    message =
                        $"Created {request.Count} " +
                        $"shapes with color " +
                        $"{request.ColorName}",
                    shapesCount = _service
                        .GetTotalShapes(),
                    uniqueColors = _service
                        .GetUniqueColors()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new { error = ex.Message });
            }
        }

        [HttpGet("shapes")]
        public IActionResult GetAllShapes()
        {
            var shapes = _service.GetAllShapes();
            return Ok(new
            {
                totalShapes = shapes.Count,
                shapes
            });
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var stats = _service.GetStats();
            return Ok(stats);
        }

        [HttpPost("display")]
        public IActionResult DisplayShapes()
        {
            _service.DisplayAllShapes();
            return Ok(new
            {
                message =
                    "Shapes displayed in console"
            });
        }

        [HttpDelete("clear")]
        public IActionResult ClearShapes()
        {
            _service.Clear();
            return Ok(new
            {
                message = "All shapes cleared"
            });
        }
    }
}
