using Api.Controllers;
using Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Xunit;
using Api.Data_Transfer_Objects;
using Api;


public class CartControllerTests
{
    private readonly DatabaseContext _dbContext;
    private readonly CartController _controller;
    private readonly int _userId = 1;

    public CartControllerTests()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new DatabaseContext(options);
        var user = new User
        {
            Id = _userId,
            Email = "test@example.com",
            Username = "testuser",
            Password = "testpassword",
            Cart = new Cart
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Quantity = 2,
                        Phone = new Phone
                        {
                            Price = 500,
                            Brand = new Brand { Name = "BrandX" },
                            Model = new Model { Name = "ModelY" },
                            Color = new Color { Name = "Black" },
                            Memory = 32,
                            InitialPrice = 500,
                            ImagePath = "/"
                        }
                    }
                }
            }
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, _userId.ToString())
        }, "mock"));

        _controller = new CartController(_dbContext);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = userClaims }
        };
    }

    [Fact]
    public void UpdateItemQuantity_ReturnsOk_WhenValidRequest()
    {
        var request = new UpdateItemQuantityRequest { Quantity = 5 };

        var result = _controller.UpdateItemQuantity(1, request);

        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.Value.Should().BeEquivalentTo(new { message = "Item 1 quantity updated to 5" });

        var updatedItem = _dbContext.Items.First(i => i.Id == 1);
        updatedItem.Quantity.Should().Be(5);
    }

    [Fact]
    public void UpdateItemQuantity_ReturnsUnauthorized_WhenInvalidToken()
    {
        var controllerWithoutAuth = new CartController(_dbContext);
        controllerWithoutAuth.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        var request = new UpdateItemQuantityRequest { Quantity = 5 };
        var result = controllerWithoutAuth.UpdateItemQuantity(1, request);

        result.Should().BeOfType<UnauthorizedObjectResult>();
    }

    [Fact]
    public void GetCartItems_ReturnsUnauthorized_WhenInvalidToken()
    {
        var controllerWithoutAuth = new CartController(_dbContext);
        controllerWithoutAuth.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext() // No token provided
        };

        var result = controllerWithoutAuth.GetCartItems();

        result.Should().BeOfType<UnauthorizedObjectResult>();
    }

    [Fact]
    public void AddPhoneToCart_ReturnsCreated_WhenValidRequest()
    {
        var request = new AddPhoneToCartRequest { PhoneId = 1 };

        var result = _controller.AddPhoneToCart(request);

        var createdResult = result as CreatedAtActionResult;
        createdResult.Should().NotBeNull();
        createdResult.Value.Should().BeEquivalentTo(new { message = "Item successfully added." });

        var item = _dbContext.Items.FirstOrDefault(i => i.PhoneId == request.PhoneId);
        item.Should().NotBeNull();
    }

    [Fact]
    public void AddPhoneToCart_ReturnsUnauthorized_WhenInvalidToken()
    {
        var controllerWithoutAuth = new CartController(_dbContext);
        controllerWithoutAuth.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext() // No token provided
        };

        var request = new AddPhoneToCartRequest { PhoneId = 1 };
        var result = controllerWithoutAuth.AddPhoneToCart(request);

        result.Should().BeOfType<UnauthorizedObjectResult>();
    }

    [Fact]
    public void RemovePhoneFromCart_ReturnsNoContent_WhenValidRequest()
    {
        var request = new AddPhoneToCartRequest { PhoneId = 1 };
        _controller.AddPhoneToCart(request); // Add the item first

        var result = _controller.RemovePhoneFromCart(1); // Remove the item by ID

        result.Should().BeOfType<NoContentResult>();

        var item = _dbContext.Items.FirstOrDefault(i => i.Id == 1);
        item.Should().BeNull(); // Ensure item is removed
    }

    [Fact]
    public void RemovePhoneFromCart_ReturnsUnauthorized_WhenInvalidToken()
    {
        var controllerWithoutAuth = new CartController(_dbContext);
        controllerWithoutAuth.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext() // No token provided
        };

        var result = controllerWithoutAuth.RemovePhoneFromCart(1);

        result.Should().BeOfType<UnauthorizedObjectResult>();
    }
}
