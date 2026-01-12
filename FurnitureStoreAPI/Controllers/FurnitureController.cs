using FurnitureStoreAPI.Patterns.Singleton;
using FurnitureStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FurnitureController : ControllerBase
    {
        private readonly FurnitureService _furnitureService;

        public FurnitureController(FurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        [HttpGet("all")]
        public IActionResult GetAllFurniture()
        {
            Logger.GetInstance().Log("Fetching all furniture");
            return Ok(_furnitureService.GetAllFurnitures());
        }

        [HttpGet("{id}")]
        public IActionResult GetFurnitureById(int id)
        {
            var furniture = _furnitureService.GetFurnitureById(id);
            if (furniture == null)
            {
                return NotFound("Furniture Not Found");
            }
            return Ok(furniture);
        }



        [HttpPost("create-custom")]
        public IActionResult CreateCustomFurniture(
            [FromBody] CreateFurnitureRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }
            var furniture = _furnitureService.CreateCustomFurniture(
                request.Name,
                request.Style,
                request.Price,
                request.Material,
                request.Color);

            return CreatedAtAction(
                nameof(GetFurnitureById),
                new { id = furniture.Id },
                furniture);
        }

        [HttpPost("create-by-type/{type}")]
        public IActionResult CreateFurnitureByType(string type)
        {
            try
            {
                var furniture = _furnitureService.CreateFurnitureByType(type);

                return CreatedAtAction(
                    nameof(GetFurnitureById),
                    new { id = furniture.Id },
                    furniture);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-set/{style}")]
        public IActionResult CreateFurnitureSet(string style)
        {
            try
            {
                var furniture = _furnitureService.CreateFurnitureSet(style);

                return CreatedAtAction(
                    nameof(GetAllFurniture),
                    furniture);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("clone/{id}")]
        public IActionResult CloneFurniture(int id)
        {
            try
            {
                var cloned = _furnitureService.CloneFurniture(id);

                return CreatedAtAction(
                    nameof(GetFurnitureById),
                    new { id = cloned.Id },
                    cloned);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("logs")]
        public IActionResult GetLogs()
        {
            return Ok(Logger.GetInstance().GetAllLogs());
        }

        // CREATIONAL DESIGN PATTERN
        // ADAPTER PATTERN
        [HttpGet("supplier/{supplierName}")]
        public IActionResult GetFurnitureFromSupplier(string supplierName)
        {
            try
            {
                var furniture = _furnitureService.GetFurnitureFromSupplier(supplierName);

                return Ok(furniture);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("suppliers")]
        public IActionResult GetAllSuppliers()
        {
            var suppliers = _furnitureService.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("by-suplier/{supplierName}")]
        public IActionResult GetFurnitureBySupplier(string supplierName)
        {
            var furniture = _furnitureService.GetFurnitureBySupplier(supplierName);

            if (furniture == null || furniture.Count == 0)
                return NotFound($"No furniture found from {supplierName}");

            return Ok(furniture);
        }
    }

    public class  CreateFurnitureRequest
    {
        public string Name { get; set; }
        public  string Style { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
    }
}
