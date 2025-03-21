using Api.Data_Transfer_Objects;
using Api.enums;
using Api.Models;
using Api.Services;
using Api.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpPatch("item/{id}")]
        [Authorize]
        public IActionResult UpdateItemQuantity([FromRoute] int id, [FromBody] UpdateItemQuantityRequest request)
        {
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId is null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

            var item = _context.Items.Where(i => i.Id == id)
                                     .Single();

            var cart = _context.Carts.Where(c => c.UserId == userId)
                                     .Single();

            if (item.CartId != cart.Id)
            {
                return Forbid();
            }

            item.Quantity = request.Quantity;
            _context.SaveChanges();

            return Ok(new { message = $"Item {id} quantity updated to {request.Quantity}" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCartItems()
        {
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId is null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

            var cart = _context.Carts.Include(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Brand)
                                     .Include(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Model)
                                     .Include(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                         .ThenInclude(p => p.Color)
                                     .Where(c => c.UserId == userId)
                                         .Single();

            var items = cart!.Items;

            return Ok(new
            {
                items = items.Select(i => new
                {
                    i.Id,
                    i.Quantity,
                    Phone = new
                    {
                        id = i.Phone.Id,
                        brand = i.Phone.Brand.Name,
                        model = i.Phone.Model.Name,
                        color = i.Phone.Color.Name,
                        price = i.Phone.Price,
                        memory = i.Phone.Memory,
                        imagePath = i.Phone.ImagePath
                    },
                    price = i.Quantity * i.Phone.Price
                }),
                subtotal = items.Sum(i => i.Phone.Price * i.Quantity)
            });
        }        

        [HttpPost]
        [Authorize]
        [Route("add")]
        public IActionResult AddPhoneToCart([FromBody] AddPhoneToCartRequest request)
        {
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId == null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

            var cart = _context.Users.Include(u => u.Cart)
                                     .Where(u => u.Id == userId)
                                     .Single().Cart;

            var phone = _context.Phones.Where(p => p.Id == request.PhoneId)
                                       .Single();

            var item = new Item { 
                Phone = phone, 
                Cart = cart, 
                Quantity = 1
            };

            _context.Items.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(AddPhoneToCart),
                new { message = "Item successfully added." }
            );
        }

        [HttpDelete]
        [Authorize]
        [Route("remove")]
        public IActionResult RemovePhoneFromCart([FromBody] RemovePhoneFromCartRequest request)
        {
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId is null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

            var cart = _context.Users.Include(u => u.Cart)
                                     .Where(u => u.Id == userId)
                                     .Single().Cart;

            var item = _context.Items.Where(i => i.Id == request.ItemId)
                                     .Single();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
