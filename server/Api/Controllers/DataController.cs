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
                Brands = _context.Brands.Select(b => new { b.Id, b.Name, count = b.Phones.Count() }).ToList(),
                Colors = _context.Colors.Select(c => new { c.Id, c.Name }).ToList(),
                Shippings = _context.Shippings.Select(s => new { s.Id, s.Type, s.Cost, s.Days }).ToList()
            };

            return Ok(data);
        }

        [HttpGet("models")]
        public IActionResult GetModels([FromQuery] string? brand)
        {
            IQueryable<Brand> brands = _context.Brands.Include(b => b.Models);

            if (!string.IsNullOrEmpty(brand))
            {
                brands = brands.Where(b => EF.Functions.Like(b.Name, brand));
            }

            return Ok(brands.Select(b => new { 
                brand = b.Name,
                models = b.Models.Select(m => new {
                    m.Id, m.Name 
                }) 
            }));
        }
    }
}
