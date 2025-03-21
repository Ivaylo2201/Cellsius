using Api.Data_Transfer_Objects;
using Api.Models;
using Api.Services;
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
            this.EnsureUploadDirExists();

            try
            {
                var phone = new Phone
                {
                    BrandId = request.BrandId,
                    ModelId = request.ModelId,
                    ColorId = request.ColorId,
                    Price = request.Price,
                    Memory = request.Memory,
                    ImagePath = $"/uploads/{this.UploadImage(
                        request.Image!,
                        $"{Guid.NewGuid()}{Path.GetExtension(request.Image!.FileName)}"
                    )}"
                };

                _context.Phones.Add(phone);
                _context.SaveChanges();

                return CreatedAtAction(
                    nameof(CreatePhone),
                    new { message = "Phone created successfully." }
                );
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { message = "Foreign key constraint failed." });
            }
        }

        [HttpGet]
        public IActionResult GetPhones([FromQuery] string? brand, string? model, string? color, decimal? price, string? search, string? sort = "asc")
        {
            var query = _context.Phones
                    .Include(p => p.Brand)
                    .Include(p => p.Model)
                    .Include(p => p.Color)
                    .AsQueryable();

            var filteredQuery = GetFilteredQuery(query, search, brand, model, color, price);
            var orderedQuery = GetOrderedQuery(filteredQuery, sort);

            return Ok(ConvertToList(orderedQuery));
        }

        private void EnsureUploadDirExists()
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
        }

        private string UploadImage(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

        private static IQueryable<Phone> GetFilteredQuery(IQueryable<Phone> query, string? search, string? brand, string? model, string? color, decimal? price)
        {
            return new FilterService(query).BySearch(search)
                                           .ByBrand(brand)
                                           .ByModel(model)
                                           .ByColor(color)
                                           .ByPrice(price)
                                           .GetQuery();
        }

        private static IQueryable<Phone> GetOrderedQuery(IQueryable<Phone> query, string? sort)
        {
            if (sort == "asc")
            {
                return query.OrderBy(p => (double)p.Price);
            }

            return query.OrderByDescending(p => (double)p.Price);
        }
        
        private static IEnumerable<dynamic> ConvertToList(IQueryable<Phone> query)
        {
            return query.Select(p => new
            {
                p.Id,
                Brand = p.Brand.Name,
                Model = p.Model.Name,
                Color = p.Color.Name,
                p.Price,
                p.Memory,
                p.ImagePath,
            }).ToList();
        }
    }
}
