using FurnitureStoreAPI.Models;
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

        // FACADE DESIGN PATTERN: STRUCTURAL
        [HttpPost("order")]
        public IActionResult PlaceOrder([FromBody]OrderRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Request cannot be null");
                }

                var furniture = _furnitureService.GetFurnitureById(request.FurnitureId);
                if(furniture == null)
                {
                    return NotFound("Furniture not found");
                }

                var orderResponse = _furnitureService.PlaceOrder(request, furniture);

                return Ok(orderResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PROXY DESIGN PATTERN
        [HttpPost("proxy/access")]
        public IActionResult GetFurnitureWithProxy(
            [FromBody] ProxyAccessRequest request)
        {
            try
            {
                var user = new User
                {
                    UserId = request.UserId,
                    Username = request.Username,
                    Email = request.Email,
                    MembershipType = request.MembershipType,
                };

                var furniture = _furnitureService.GetFurnitureWithProxy(
                    user,
                    request.FurnitureId);

                if(furniture == null)
                {
                    return NotFound("Furniture not found");
                }

                return Ok(new
                {
                    furniture,
                    userMembership = user.MembershipType,
                    message = "Access granted"
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("proxy/all")]
        public IActionResult GetAllFurnitureWithProxy(
            [FromBody] ProxyAccessRequest request)
        {
            try
            {
                var user = new User
                {
                    UserId = request.UserId,
                    Username = request.Username,
                    Email = request.Email,
                    MembershipType = request.MembershipType
                };

                var furniture = _furnitureService
                    .GetAllFurnitureWithProxy(user);

                return Ok(new
                {
                    count = furniture.Count,
                    furniture,
                    userMembership = user.MembershipType
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("proxy/price")]
        public IActionResult GetPriceWithProxy(
            [FromBody] ProxyPriceRequest request)
        {
            try
            {
                var user = new User
                {
                    UserId = request.UserId,
                    Username = request.Username,
                    Email = request.Email,
                    MembershipType = request.MembershipType
                };

                var price = _furnitureService
                    .GetPriceWithProxy(user, request.FurnitureId);

                return Ok(new
                {
                    furnitureId = request.FurnitureId,
                    originalPrice = "Check database",
                    discountedPrice = price,
                    userMembership = user.MembershipType,
                    savings = "See console logs for details"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

    // DTOs for proxy requests
    public class ProxyAccessRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public MembershipType MembershipType { get; set; }
        public int FurnitureId { get; set; }
    }

    public class ProxyPriceRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public MembershipType MembershipType { get; set; }
        public int FurnitureId { get; set; }
    }
}
