using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Api.Services;
using Api.Data_Transfer_Objects;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(DatabaseContext context, AuthService authService) : ControllerBase
    {
        private readonly DatabaseContext _context = context;
        private readonly AuthService _authService = authService;

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

            if (!EmailRegex.IsMatch(request.Email) || _context.Users.Any(u => u.Email == request.Email))
                return BadRequest(new { message = "Invalid email." });

            if (_context.Users.Any(u => u.Username == request.Username))
                return BadRequest(new { message = "Username already taken." });

            if (request.Password != request.PasswordConfirmation)
                return BadRequest(new { message = "Passwords do not match" });

            var user = new User { 
                Email = request.Email, 
                Username = request.Username, 
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Cart = new Cart()
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(Register), 
                new { id = user.Id },
                new
                {
                    token = _authService.GenerateToken(user),
                    cart = new
                    {
                        items = new List<object>(),
                        subtotal = 0
                    }
                }
            );
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRequest request)
        {
            var user = _context.Users.Where(u => u.Email == request.Email)
                                     .Include(u => u.Cart)
                                         .ThenInclude(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Brand)
                                     .Include(u => u.Cart)
                                         .ThenInclude(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Model)
                                     .Include(u => u.Cart)
                                         .ThenInclude(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Color)
                                     .FirstOrDefault();

                                            
            if (user is null)
                return NotFound(new { message = "User not found." });

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return BadRequest(new { message = "Invalid password." });

            var items = user.Cart!.Items.Select(i => new
            {
                id = i.Id,
                phone = new
                {
                    brand = i.Phone.Brand.Name,
                    model = i.Phone.Model.Name,
                    color = i.Phone.Color.Name,
                    memory = i.Phone.Memory,
                    price = i.Phone.Price,
                    image = i.Phone.ImagePath
                },
                quantity = i.Quantity,
                price = i.Quantity * i.Phone.Price
            });

            return Ok(new
            {
                token = _authService.GenerateToken(user),
                cart = new
                {
                    items,
                    subtotal = items.Select(i => i.price).Sum()
                }
            });
        }
    }
}
