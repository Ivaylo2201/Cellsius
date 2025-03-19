using Api.Data_Transfer_Objects;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController(DatabaseContext context, IWebHostEnvironment env) : ControllerBase
    {
        private readonly DatabaseContext _context = context;
        private readonly IWebHostEnvironment _env = env;

        [HttpPost]
        public IActionResult CreatePhone([FromForm] CreatePhoneRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(_env.WebRootPath))
                {
                    _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Image.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }

                var phone = new Phone
                {
                    BrandId = request.BrandId,
                    ModelId = request.ModelId,
                    ColorId = request.ColorId,
                    Price = request.Price,
                    Memory = request.Memory,
                    ImagePath = $"/uploads/{fileName}"
                };

                _context.Phones.Add(phone);
                _context.SaveChanges();

                return CreatedAtAction(nameof(CreatePhone), new { message = "Phone created successfully." });
            }
            catch (DbUpdateException e)
            {
                return BadRequest(new { message = "An error has occurred." });
            }
        }

        [HttpGet]
        public IActionResult GetPublicPhones([FromQuery] string? brand, string? model, string? color, decimal? max, string? search, string? sort = "asc")
        {
            var query = this.GetPhones(brand, model, color, max, sort, search);

            var phones = query.Select(p => new
            {
                p.Id,
                Brand = p.Brand.Name,
                Model = p.Model.Name,
                Color = p.Color.Name,
                p.Price,
                p.Memory,
                p.ImagePath,
            })
            .ToList();

            return Ok(phones);
        }

        private IQueryable<Phone> GetPhones(string? brand, string? model, string? color, decimal? max, string? sort, string? search)
        {
            var query = _context.Phones
                    .Include(p => p.Brand)
                    .Include(p => p.Model)
                    .Include(p => p.Color)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Brand.Name.ToLower().Contains(search.ToLower()) || p.Model.Name.ToLower().Contains(search.ToLower()));

            if (!string.IsNullOrEmpty(brand))
                query = query.Where(p => p.Brand.Name.ToLower().Contains(brand.ToLower()));

            if (!string.IsNullOrEmpty(model))
                query = query.Where(p => p.Model.Name.ToLower().Contains(model.ToLower()));

            if (!string.IsNullOrEmpty(color))
                query = query.Where(p => p.Color.Name.ToLower().Contains(color.ToLower()));

            if (max.HasValue)
                query = query.Where(p => p.Price <= max.Value);


            query = sort == "asc" ? query.OrderBy(p => ((double)p.Price)) :
                                    query.OrderByDescending(p => ((double)p.Price));

            return query;
        }
    }
}
