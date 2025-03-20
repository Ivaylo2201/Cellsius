using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(new
            {
                Brands = _context.Brands.Select(b => new { b.Id, b.Name }).ToList(),
                Colors = _context.Colors.Select(c => new { c.Id, c.Name }).ToList(),
                Shippings = _context.Shippings.Select(s => new { s.Id, s.Type, s.Cost, s.Days }).ToList()
            });
        }

        [HttpGet("models")]
        public IActionResult GetModels([FromQuery] string? brand)
        {
            return Ok(_context.Models
                        .Where(m => m.Brand.Name == brand)
                        .Select(m => new { m.Id, m.Name })
                        .ToList()
            );
        }
    }
}
