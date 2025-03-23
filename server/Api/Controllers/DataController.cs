using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var data = new
            {
                Brands = _context.Brands.Select(b => new { b.Id, b.Name }).ToList(),
                Colors = _context.Colors.Select(c => new { c.Id, c.Name }).ToList(),
                Shippings = _context.Shippings.Select(s => new { s.Id, s.Type, s.Cost, s.Days }).ToList()
            };

            return Ok(data);
        }

        [HttpGet("models")]
        public IActionResult GetModels([FromQuery] string? brand)
        {
            IQueryable<Model> models = _context.Models;

            if (!string.IsNullOrEmpty(brand))
            {
               models = models.Where(m => EF.Functions.Like(m.Brand.Name, brand));
            }

            return Ok(models.Select(m => new { m.Id, m.Name }).ToList());
        }
    }
}
