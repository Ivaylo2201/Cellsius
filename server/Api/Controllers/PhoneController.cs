using Api.Data_Transfer_Objects;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/phones")]
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
                    InitialPrice = request.Price,
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
        public IActionResult GetPhones([FromQuery] string? brand, string? models, string? color, decimal? minPrice, decimal? maxPrice, string? search, string? sortBy, string? order = "asc")
        {
            var query = _context.Phones
                    .Include(p => p.Brand)
                    .Include(p => p.Model)
                    .Include(p => p.Color)
                    .AsQueryable();

            var filteredQuery = GetFilteredQuery(query, search, brand, models, color, minPrice, maxPrice);
            var orderedQuery = GetOrderedQuery(filteredQuery, sortBy, order);

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

        private static IQueryable<Phone> GetFilteredQuery(IQueryable<Phone> query, string? search, string? brand, string? models, string? color, decimal? minPrice, decimal? maxPrice)
        {
            return new FilterService(query).BySearch(search)
                                           .ByBrand(brand)
                                           .ByModels(models)
                                           .ByColor(color)
                                           .ByPrice(minPrice, maxPrice)
                                           .GetQuery();
        }

        private static IQueryable<Phone> GetOrderedQuery(IQueryable<Phone> query, string? sortBy, string? order)
        {
            Dictionary<string, Expression<Func<Phone, double>>> fieldMap = new()
            {
                { "price", p => (double) p.Price },
                { "discount", p => (double) p.DiscountPercentage }
            };

            if (sortBy is null || !fieldMap.ContainsKey(sortBy))
            {
                return query;
            }
            else
            {
                IQueryable<Phone> ordered = order == "asc" ? query.OrderBy(fieldMap[sortBy]) : query.OrderByDescending(fieldMap[sortBy]);
                return ordered;
            }
        }
        
        private static IEnumerable<dynamic> ConvertToList(IQueryable<Phone> query)
        {
            return query.Select(p => new
            {
                p.Id,
                Brand = p.Brand!.Name,
                Model = p.Model!.Name,
                Color = p.Color!.Name,
                p.DiscountPercentage,
                price = new {
                    initial = p.InitialPrice,
                    discounted = p.Price
                },
                p.Memory,
                p.ImagePath,
            }).ToList();
        }
    }
}
